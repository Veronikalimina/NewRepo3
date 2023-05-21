using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class LivingInRentedFlats
    {
        [Key]
        public Int64 IdEntryLivingInRentedFlats { get; set; }
        public Int64 IdStudent { get; set; }
        public string? Adress { get; set; } = "";
    }
}
