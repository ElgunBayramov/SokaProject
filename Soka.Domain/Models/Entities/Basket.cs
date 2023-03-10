using Soka.Domain.AppCode.Infrastructure;

namespace Soka.Domain.Models.Entities
{
    public class Basket : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
