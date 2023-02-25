using Microsoft.AspNetCore.Http;

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
    }
}
