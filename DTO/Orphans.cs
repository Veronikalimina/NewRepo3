using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class Orphans
    {
        [Key]
        public Int64 IdEntryOrphans { get; set; }
        public Int64 IdStudent { get; set; }
    }
}
