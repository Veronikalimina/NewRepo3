using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class ActiveGroup
    {
        [Key]
        public Int64 IdActiveGroup { get; set; }
        public Int64 IdGroup { get; set; }
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
