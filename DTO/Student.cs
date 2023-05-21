using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class Student
    {
        [Key]
        public Int64 IdStudent { get; set; }
        public Int64 IdGroup { get; set; }
        public string Surname { get; set; } = "";
        public string Name { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public DateTime Birthdate { get; set; }
    }
}
