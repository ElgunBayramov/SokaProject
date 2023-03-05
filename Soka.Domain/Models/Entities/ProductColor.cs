using Soka.Application.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Soka.Domain.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
    }
}
