﻿using Soka.Application.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Soka.Domain.Models.Entities
{
    public class ProductSize : BaseEntity
    {
        public string Name { get; set; }
    }
}
