using System;
using Soka.Domain.Models.Entities.Membership;

namespace Soka.Domain.AppCode.Infrastructure
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual SokaUser CreatedByUser { get; set; }
        public DateTime CreatedTime { get; set; }=DateTime.UtcNow.AddHours(4);
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }
        public virtual SokaUser DeletedByUser { get; set; }
    }
}
