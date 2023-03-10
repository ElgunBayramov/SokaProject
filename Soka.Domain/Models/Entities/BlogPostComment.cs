using Soka.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace Soka.Domain.Models.Entities
{
    public class BlogPostComment : BaseEntity
    {
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public virtual BlogPostComment Parent { get; set; }
        public virtual ICollection<BlogPostComment> Children { get; set; }
        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }
}
