﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.BlogPostModule;
using Soka.Domain.Models.DataContexts;
using System.Linq;
using System.Threading.Tasks;

namespace Soka.WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IMediator mediator;

        public BlogController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(BlogPostsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        [Route("/blog/tags/{tagId}")]
        public async Task<IActionResult> PostsByTag(BlogPostByTagQuery query)
        {
            var response = await mediator.Send(query);

            return View("Index", response);
        }
        [Route("/blog/{slug}")]
        public async Task<IActionResult> Details(BlogPostSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NotFound();
            }
            return View(response);
        }
    }
}
