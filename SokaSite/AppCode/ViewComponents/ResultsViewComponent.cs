using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.ResultModule;
using System.Threading.Tasks;

namespace Soka.WebUI.AppCode.ViewComponents
{
    public class ResultsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public ResultsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var query = new ResultsAllQuery();
            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
