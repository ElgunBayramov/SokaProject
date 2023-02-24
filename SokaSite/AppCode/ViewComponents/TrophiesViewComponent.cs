using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.TropyModule;
using System.Threading.Tasks;

namespace Soka.WebUI.AppCode.ViewComponents
{
    public class TrophiesViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public TrophiesViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new TrophiesAllQuery();
            var response = await mediator.Send(query);
            return View(response);

        }
    }
}
