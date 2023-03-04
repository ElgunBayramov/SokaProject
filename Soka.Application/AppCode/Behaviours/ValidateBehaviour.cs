using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Soka.Application.AppCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Application.AppCode.Behaviours
{
    public class ValidateBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        //private readonly IValidator<TRequest> validator;
        private readonly IActionContextAccessor ctx;

        public ValidateBehaviour(IActionContextAccessor ctx)
        {
            this.ctx = ctx;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {

            var validator = ctx.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    //throw new ValidationException(validationResult.Errors);
                    foreach (var item in validationResult.Errors)
                    {
                        ctx.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return default;
                }
            }


            //before executing
            var response = await next();
            //after executing

            return response;
        }
    }
}
