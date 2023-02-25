using Soka.Application.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
