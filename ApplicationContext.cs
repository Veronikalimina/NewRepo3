using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;

namespace WebApplication1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Authentication> Authentications { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
       
    }
}
