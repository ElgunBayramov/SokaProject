using Soka.Application.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }
        public DateTime? ApprovedDate { get; set; } 
    }
}
