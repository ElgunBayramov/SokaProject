using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.AccountModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Route("/signin.html")]
        [AllowAnonymous]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/signin.html")]
        public async Task<IActionResult> Signin(SigninCommand command)
        {
            var result = await mediator.Send(command);
            if(result == true)
            {
                var redirectUrl = Request.Query["ReturnUrl"];
                if (string.IsNullOrEmpty(redirectUrl))
                {

                return RedirectToAction("Index","Home");
                }
                return Redirect(redirectUrl);
            }
            return View(command);
        }
    }
}
