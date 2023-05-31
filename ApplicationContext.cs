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
        public DbSet<ActiveGroup> ActiveGroup { get; set; } = default!;
        public DbSet<ChildrenWithDisabilities> ChildrenWithDisabilities { get; set; } = default!;
        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<CuratorObservationSheet> CuratorObservationSheet { get; set; } = default!;
        public DbSet<EngagementWithParents> EngagementWithParents { get; set; } = default!;
        public DbSet<ExtracurricularEmploymentOfStudents> ExtracurricularEmploymentOfStudents { get; set; } = default!;
        public DbSet<FromLargeFamilies> FromLargeFamilies { get; set; } = default!;
        public DbSet<FromPoorFamilies> FromPoorFamilies { get; set; } = default!;
        public DbSet<IndividualWorkWithStudents> IndividualWorkWithStudents { get; set; } = default!;
        public DbSet<LiveInAHostel> LiveInAHostel { get; set; } = default!;
        public DbSet<LivingInRentedFlats> LivingInRentedFlats { get; set; } = default!;
        public DbSet<OneParent> OneParent { get; set; } = default!;
        public DbSet<Orphans> Orphans { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

    }
}
