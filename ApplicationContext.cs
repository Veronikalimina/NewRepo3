using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;

namespace WebApplication1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Curator> Curators { get; set; }
        public DbSet<Authentication> Authentications { get; set; } = null!;
        public DbSet<AccountingForClassHoursByStudents> AccountingForClassHoursByStudents { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
            .HasOne(p => p.Curator)
            .WithMany(b => b.Groups)
            .HasForeignKey(b => b.IdCurator);
        }
    }
}
