using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class Course
    {
        [Key]
        public Int64 idCourse { get; set; }
        public Int16 NumberCourse { get; set; }
    }
}
