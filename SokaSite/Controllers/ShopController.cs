using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Soka.Application.AppCode.Extensions;
using Soka.Domain.Business.FilterModule;
using Soka.Domain.Business.ProductModule;
using Soka.Domain.Business.ShopModule;
using System.Linq;
using System.Threading.Tasks;

namespace Soka.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator mediator;

        public ShopController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(SearchFilterQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", response);
            }

            return View(response);
        }
        [Route("/product/{id}")]
        public async Task<IActionResult> Details(ProductSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [AllowAnonymous]
        [Route("wishlist.html")]
        public async Task<IActionResult> WishList(WishlistQuery query)
        {
            var response = await mediator.Send(query);

            if (response != null)
            {
                return View(response);
            }

            TempData["InfoMessage"] = "Istək səhifəniz boşdur";
            if(Request.Headers.TryGetValue("Referer", out StringValues values))
            {
                return Redirect(values.First());
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket(AddToBasketCommand command)
        {
            var response = await mediator.Send(command);

            return Json(response);
        }
        [Route("basket.html")]
        [AllowAnonymous]
        public async Task<IActionResult> Basket(BasketQuery query)
        {
            var response = await mediator.Send(query);

            if (response != null)
            {
                return View(response);
            }

            TempData["InfoMessage"] = "Səbətiniz boşdur";
            if (Request.Headers.TryGetValue("Referer", out StringValues values))
            {
                return Redirect(values.First());
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
