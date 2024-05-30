using Soka.Domain.Business.UserModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Soka.Application.AppCode.Extensions;
using Soka.Domain.Models.Entities.Membership;
using Soka.Domain.Models.DataContexts;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "sa")]
    public class UsersController : Controller
    {
        private readonly IMediator mediator;
        private readonly SokaDbContext db;

        public UsersController(IMediator mediator,SokaDbContext db)
        {
            this.mediator = mediator;
            this.db = db;
        }

        public async Task<IActionResult> Index(UsersPagedQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListBody", response);
            }

            return View(response);
        }

        public async Task<IActionResult> Details(UserDetailQuery query)
        {
            ViewBag.AvailableRoles = await mediator.Send(new UserAvailableRolesQuery() { UserId = query.Id });
            ViewBag.AvailablePrincipals = await mediator.Send(new UserAvailablePrincipalsQuery() { UserId = query.Id });

            var data = await mediator.Send(query);

            return View(data);
        }

        [HttpPost]
        [Authorize(Policy = "admin.users.setrole")]
        public async Task<IActionResult> SetRole(UserSetRoleCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }

        [HttpPost]
        [Authorize(Policy = "admin.users.setprincipal")]
        public async Task<IActionResult> SetPrincipal(UserSetPrincipalCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }
    }
}
