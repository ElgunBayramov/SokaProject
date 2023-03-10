using Soka.Domain.AppCode.Infrastructure;

namespace Soka.Domain.Models.Entities
{
    public class Tropy : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
    }
}
