using Soka.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace Soka.Domain.Models.Entities
{
    public class Tag : BaseEntity
    {
        public string Text { get; set; }
        public virtual ICollection<BlogPostTagCloud> TagCloud { get; set; }
    }
}
