using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class ExtracurricularEmploymentOfStudents
    {
        [Key]
        public Int64 IdExtracurricularEmploymentOfStudents { get; set; }
        public Int64 IdCourse { get; set; }
        public Int64 IdStudent { get; set; }
        public string? CollegeActivity { get; set; } = "";
        public string? ActivitiesOutsideCollege { get; set; } = "";
    }
}
