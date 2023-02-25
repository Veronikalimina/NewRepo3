namespace WebApplication1.DTO
{
    public class Student
    {
        public int IdStudent { get; set; }
        public int IdGroup { get; set; }
        public string Surname { get; set; } = "";
        public string Name { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public DateOnly Birthdate { get; set; }
    }
}
