using Soka.Application.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Soka.Domain.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        [Required(ErrorMessage = "{0} boş buraxıla bilməz!")]
        public string Name { get; set; }
    }
}
