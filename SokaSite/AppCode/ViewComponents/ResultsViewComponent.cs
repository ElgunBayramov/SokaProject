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
        public async Task<IViewComponentResult> InvokeAsync(int size)
        {
            var query = new ResultRecentQuery();
            query.Size = size;

            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
