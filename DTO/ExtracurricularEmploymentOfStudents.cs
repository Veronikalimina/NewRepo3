namespace WebApplication1.DTO
{
    public class ExtracurricularEmploymentOfStudents
    {
        public int IdExtracurricularEmploymentOfStudents { get; set; }
        public int IdCourse { get; set; }
        public int IdStudent { get; set; }
        public string CollegeActivity { get; set; } = "";
        public string ActivitiesOutsideCollege { get; set; } = "";
    }
}
