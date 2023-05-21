using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class EngagementWithParents
    {
        [Key]
        public Int64 IdEngagementWithParents { get; set; }
        public DateTime DateConversation { get; set; }
        public Int64 IdStudent { get; set; }
        public string? EssenceOfConversation { get; set; } = "";
        public string? AcceptedDecision { get; set; } = "";
    }
}
