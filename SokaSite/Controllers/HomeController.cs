using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Soka.Domain.AppCode.Services;
using Soka.Domain.Business.FaqModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Soka.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly SokaDbContext db;
        private readonly CryptoService crypto;
        private readonly EmailService emailService;
        private readonly IMediator mediator;

        public HomeController(SokaDbContext db,CryptoService crypto,EmailService emailService,IMediator mediator)
        {
            this.db = db;
            this.crypto = crypto;
            this.emailService = emailService;
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            var data = db.BlogPosts.Where(bp => bp.DeletedDate == null).ToList();
            return View(data);
        }
        [Route("/about")]
        public async Task<IActionResult> About(FaqsAllQuery query)
        {
            var faqs = await mediator.Send(query);
            return View(faqs);
        }
        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [Route("/contact")]
        public IActionResult Contact(ContactPost model)
        {
            db.ContactPosts.Add(model);
            TempData["message"] = "Hörmətli istifadəçi, müraciətiniz qəbul edildi!";
            db.SaveChanges();
            return RedirectToAction(nameof(Contact));
        }
        public async Task<IActionResult> Subscribe(string email)
        {
            var subscriber = await db.Subscribers.FirstOrDefaultAsync(s => s.Email.Equals(email));
            if (subscriber != null && subscriber.ApprovedDate != null)
            {
                return Json(new
                {
                    error = false,
                    message = "Siz artıq abunəsiniz!"
                });
            }
            else if (subscriber != null)
            {
                goto end;
            }
            else
            {
                subscriber = new Subscribe();
                subscriber.Email = email;
                await db.Subscribers.AddAsync(subscriber);
                await db.SaveChangesAsync();
                //string token = $"{subscriber.Id}-{subscriber.Email}".Encrypt(Extension.saltKey,true);
                string token = crypto.Encrypt($"{subscriber.Id}-{subscriber.Email}", true);
                string approveLink = $"https://{Request.Host}/subscribe-approve?token={token}";
                await emailService.SendEmailAsync(email, approveLink);
            }

        end:
            return Json(new
            {
                error = false,
                message = "E-poçt adresinizə təsdiq mesajı göndərildi"
            });
        }
        [Route("/subscribe-approve")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            token = crypto.Decrypt(token);
            var match = Regex.Match(token, @"^(?<id>\d+)-(?<email>.+)$");
            if (!match.Success)
            {
                return Content("token zedelidir");
            }

            int id = Convert.ToInt32(match.Groups["id"].Value);
            string email = match.Groups["email"].Value;

            var subscriber = await db.Subscribers.FirstOrDefaultAsync(s => s.Id == id);

            if (subscriber == null)
            {
                return Content("tapilmadi");
            }
            else if (!subscriber.Email.Equals(email))
            {
                return Content("token size aid deyil");
            }
            else if (subscriber.ApprovedDate != null)
            {
                return Content("abuneliyiniz artiq tesdiq edilib");

            }
            subscriber.ApprovedDate = DateTime.UtcNow.AddHours(4);
            await db.SaveChangesAsync();


            return Content("ugurludur");
        }
    }
}


