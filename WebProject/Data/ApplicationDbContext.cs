using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Message> Messages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
    }
}