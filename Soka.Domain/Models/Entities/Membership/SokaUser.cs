using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Models.Entities.Membership
{
    public class SokaUser : IdentityUser<int>
    {
        public string ProfileImagePath { get; set; }
        public string CoverImagePath { get; set; }
    }
}
