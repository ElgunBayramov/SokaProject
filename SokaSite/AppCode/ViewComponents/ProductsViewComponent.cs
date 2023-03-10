using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace Soka.WebUI.AppCode.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ProductsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int size)
        {
            var query = new ProductRecentQuery();
            query.Size = size;

            var response = await mediator.Send(query);
            return View(response);

        }
    }
}
