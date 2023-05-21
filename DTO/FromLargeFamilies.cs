using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class FromLargeFamilies
    {
        [Key]
        public Int64 IdEntryFromLargeFamilies { get; set; }
        public Int64 IdStudent { get; set; }
    }
}
