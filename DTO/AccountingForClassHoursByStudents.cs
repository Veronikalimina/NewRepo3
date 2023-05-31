using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTO
{
    public class AccountingForClassHoursByStudents
    {
        [Key]
        public Int64 IdAccountingForClassHoursByStudents { get; set; }
        [ForeignKey("Stusent")]
        public Int64 IdStudent { get; set; }
        public DateTime ClassHourDate { get; set; }
    }
}
