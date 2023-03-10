using Soka.Domain.AppCode.Infrastructure;

namespace Soka.Domain.Models.Entities
{
    public class Faq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
