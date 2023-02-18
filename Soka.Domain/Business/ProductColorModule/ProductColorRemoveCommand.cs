﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.AppCode.Infrastructure;
using Soka.Domain.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.ProductColorModule
{
    public class ProductColorRemoveCommand : IRequest<JsonResponse>
    {
        public int Id { get; set; }
        public class ProductColorRemoveCommandHandler : IRequestHandler<ProductColorRemoveCommand, JsonResponse>
        {
            private readonly SokaDbContext db;

            public ProductColorRemoveCommandHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<JsonResponse> Handle(ProductColorRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Colors.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null);
                if (entity == null)
                {
                    return new JsonResponse
                    {
                        Error = true,
                        Message = "Qeyd tapilmadi"
                    };
                }
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new JsonResponse
                {
                    Error = false,
                    Message = "Ugurludur"
                };
            }
        }
    }
}