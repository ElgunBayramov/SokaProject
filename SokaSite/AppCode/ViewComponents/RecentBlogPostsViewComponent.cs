using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.BlogPostModule;
using System.Threading.Tasks;

namespace Soka.WebUI.AppCode.ViewComponents
{
    public class RecentBlogPostsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RecentBlogPostsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(int size)
        {
            var query = new BlogPostRecentQuery();
            query.Size = size;

            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
