using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class CuratorObservationSheet
    {
        [Key]
        public Int64 IdCuratorObservationSheet { get; set; }
        public Int64 IdStudent { get; set; }
        public string? BriefDescription { get; set; } = "";
    }
}
