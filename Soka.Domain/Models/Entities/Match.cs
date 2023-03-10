using Soka.Domain.AppCode.Infrastructure;
using System;

namespace Soka.Domain.Models.Entities
{
    public class Match : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public DateTime? GameDate { get; set; }
    }
}
