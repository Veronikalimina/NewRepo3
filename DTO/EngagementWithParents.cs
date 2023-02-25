namespace WebApplication1.DTO
{
    public class EngagementWithParents
    {
        public int IdEngagementWithParents { get; set; }
        public DateOnly DateConversation { get; set; }
        public int IdStudent { get; set; }
        public string EssenceOfConversation { get; set; } = "";
        public string AcceptedDecision { get; set; } = "";
    }
}
