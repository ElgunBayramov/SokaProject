using Soka.Application.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.Entities
{
    public class Result : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public string RivalImagePath { get; set; }
        public string ClubName { get; set; }
        public string RivalClubName { get; set; }
        public DateTime? GameDate { get; set; }
    }
}
