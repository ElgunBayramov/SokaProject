using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Soka.Application.AppCode.Extensions
{
    static public partial class Extension
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request.Headers != null)
            {
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }

            return false;
        }
        public static TService GetService<TService>(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.HttpContext.RequestServices.GetService<TService>();
        }

        public static TService GetService<TService>(this IHttpContextAccessor ctx)
        {
            return ctx.HttpContext.RequestServices.GetService<TService>();
        }
    }
}
