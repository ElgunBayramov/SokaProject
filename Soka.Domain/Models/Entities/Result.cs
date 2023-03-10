using Soka.Domain.AppCode.Infrastructure;
using System;

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
