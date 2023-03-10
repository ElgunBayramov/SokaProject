using Microsoft.AspNetCore.Identity;

namespace Soka.Domain.Models.Entities.Membership
{
    public class SokaRole : IdentityRole<int>
    {
        public byte Rank { get; set; }
    }
}
