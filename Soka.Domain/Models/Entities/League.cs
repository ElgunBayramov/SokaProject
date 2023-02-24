using Soka.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.Entities
{
    public class League : BaseEntity
    {
        public string Body { get; set; }
        public string Venue { get; set; }
        public DateTime? GameDate { get; set; }
    }
}
