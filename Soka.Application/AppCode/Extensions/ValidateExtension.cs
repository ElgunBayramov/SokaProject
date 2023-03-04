using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Application.AppCode.Extensions
{
    public static partial class Extension
    {
        static public IActionContextAccessor AddModelError(this IActionContextAccessor ctx, string propertyName, string error)
        {
            ctx.ActionContext.ModelState.AddModelError(propertyName, error);

            return ctx;
        }
    }
}
