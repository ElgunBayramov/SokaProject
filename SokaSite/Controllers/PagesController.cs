using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.LeagueModule;
using Soka.Domain.Business.ResultModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Controllers
{
    [AllowAnonymous]
    public class PagesController : Controller
    {
        private readonly IMediator mediator;

        public PagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(LeaguesAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public async Task<IActionResult> Details(ResultsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
