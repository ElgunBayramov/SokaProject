using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Soka.Domain.AppCode.Extensions;
using Soka.Domain.Business.BlogPostModule;
using Soka.Domain.Business.TagModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BlogPostsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public async Task<IActionResult> Publish(BlogPostPublishCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }

        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            var tags = await mediator.Send(new TagsAllQuery());
            ViewBag.TagId = new SelectList(tags, "Id", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostCreateCommand command)
        {
            if(command.Image == null)
            {
                ModelState.AddModelError("Image", "Şəkil seçilməyib");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name",command.CategoryId);
            var tags = await mediator.Send(new TagsAllQuery());
            ViewBag.TagId = new SelectList(tags, "Id", "Text");
            return View(command);
        }
        public async Task<IActionResult> Edit(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NotFound();
            }
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name",response.CategoryId);
            var tags = await mediator.Send(new TagsAllQuery());
            ViewBag.TagId = new SelectList(tags, "Id", "Text");
            var command = new BlogPostEditCommand();
            command.Title = response.Title;
            command.Body = response.Body;
            command.CategoryId = response.CategoryId;
            command.ImagePath = response.ImagePath;
            command.TagIds = response.TagCloud.Select(tc => tc.TagId).ToArray();
            return View(command);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogPostEditCommand command)
        {
            var response = await mediator.Send(command); 
            if(response == null)
            {
                var categories = await mediator.Send(new CategoryAllQuery());
                ViewBag.CategoryId = new SelectList(categories, "Id", "Name", response.CategoryId);
                var tags = await mediator.Send(new TagsAllQuery());
                ViewBag.TagId = new SelectList(tags, "Id", "Text");
                return View(command);
            }

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Remove(BlogPostRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new BlogPostsAllQuery());
            return PartialView("_ListBody", data);
        }

    }
}
