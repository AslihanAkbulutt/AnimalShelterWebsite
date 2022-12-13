using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace WebProject.Models
{
    public class UserDetails: IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
