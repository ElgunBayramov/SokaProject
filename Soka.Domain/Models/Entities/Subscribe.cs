using Soka.Domain.AppCode.Infrastructure;
using System;

namespace Soka.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }
        public DateTime? ApprovedDate { get; set; } 
    }
}
