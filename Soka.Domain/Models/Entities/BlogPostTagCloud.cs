using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.Entities
{
    public class BlogPostTagCloud
    {
        public int BlogPostId { get; set; }
        public int TagId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
