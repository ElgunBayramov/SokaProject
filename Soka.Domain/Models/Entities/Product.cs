using Soka.Application.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal? Rate { get; set; } = 0;
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; } = 0;
        public virtual Brand Brand { get; set; }
        public int CategoryId { get; set; } = 0;
        public virtual Category Category { get; set; }
    }
}
