using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class AccountingForClassHoursByStudents
    {
        [Key]
        public Int64 IdAccountingForClassHoursByStudents { get; set; }
        public Int64 IdStudent { get; set; }
        public DateTime ClassHourDate { get; set; }
    }
}
