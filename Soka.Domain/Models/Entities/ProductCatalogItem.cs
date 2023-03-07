using Soka.Application.AppCode.Infrastructure;
using Soka.Domain.Models.Entities;

namespace Soka.Domain.Models.Entities
{
    public class ProductCatalogItem : BaseEntity
    {
        public int ColorId { get; set; }
        public virtual ProductColor Color { get; set; }
        public int SizeId { get; set; }
        public virtual ProductSize Size { get; set; }
        public int TypeId { get; set; }
        public virtual ProductType Type { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
