using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.BlogPostModule;
using Soka.Domain.Models.DataContexts;
using System.Threading.Tasks;

namespace Soka.WebUI.AppCode.ViewComponents
{
    public class RelatedBlogPostsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public RelatedBlogPostsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(int postId,int size)
        {
            var query = new BlogPostRelatedQuery();
            query.PostId = postId;
            query.Size = size;

            var response = await mediator.Send(query);
            return View(response);
        }
    }
}
