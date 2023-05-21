using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class LiveInAHostel
    {
        [Key]
        public Int64 IdEntryLiveInAHostel { get; set; }
        public Int64 IdStudent { get; set; }
        public int NumberRoom { get; set; }
    }
}
