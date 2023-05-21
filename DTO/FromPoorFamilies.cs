using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class FromPoorFamilies
    {
        [Key]
        public Int64 IdEntryFromPoorFamilies { get; set; }
        public Int64 IdStudent { get; set; }
    }
}
