using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class OneParent
    {
        [Key]
        public Int64 IdEntryOneParent { get; set; }
        public Int64 IdStudent { get; set; }
    }
}
