namespace WebApplication1.DTO
{
    public class ActiveGroup
    {
        public int IdActiveGroup { get; set; }
        public int IdGroup { get; set; }
        public string Warden { get; set; } = "";
        public string DeputyWarden { get; set; } = "";
        public string CommitteeForEducationalActivities { get; set; } = "";
        public string DraftingCommittee { get; set; } = "";
        public string SportsCommittee { get; set; } = "";
        public string LaborCommittee { get; set; } = "";
        public string CommitteeForCulturalWork { get; set; } = "";
        public string ScholarshipCommission { get; set; } = "";
    }
}
