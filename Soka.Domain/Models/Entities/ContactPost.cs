using Soka.Domain.AppCode.Infrastructure;
using System;

namespace Soka.Domain.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public DateTime? AnsweredDate { get; set; }

    }
}
