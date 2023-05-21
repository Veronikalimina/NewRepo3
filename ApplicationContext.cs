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


        


        public DbSet<WebApplication1.DTO.ActiveGroup> ActiveGroup { get; set; } = default!;


        public DbSet<WebApplication1.DTO.ChildrenWithDisabilities> ChildrenWithDisabilities { get; set; } = default!;


        public DbSet<WebApplication1.DTO.Course> Course { get; set; } = default!;


        public DbSet<WebApplication1.DTO.CuratorObservationSheet> CuratorObservationSheet { get; set; } = default!;


        public DbSet<WebApplication1.DTO.EngagementWithParents> EngagementWithParents { get; set; } = default!;


        public DbSet<WebApplication1.DTO.ExtracurricularEmploymentOfStudents> ExtracurricularEmploymentOfStudents { get; set; } = default!;


        public DbSet<WebApplication1.DTO.FromLargeFamilies> FromLargeFamilies { get; set; } = default!;


        public DbSet<WebApplication1.DTO.FromPoorFamilies> FromPoorFamilies { get; set; } = default!;


        public DbSet<WebApplication1.DTO.IndividualWorkWithStudents> IndividualWorkWithStudents { get; set; } = default!;


        public DbSet<WebApplication1.DTO.LiveInAHostel> LiveInAHostel { get; set; } = default!;


        public DbSet<WebApplication1.DTO.LivingInRentedFlats> LivingInRentedFlats { get; set; } = default!;


        public DbSet<WebApplication1.DTO.OneParent> OneParent { get; set; } = default!;


        public DbSet<WebApplication1.DTO.Orphans> Orphans { get; set; } = default!;


        public DbSet<WebApplication1.DTO.Student> Student { get; set; } = default!;
    }
}
