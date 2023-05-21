using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class IndividualWorkWithStudents
    {
        [Key]
        public Int64 IdIndividualWorkWithStudents { get; set; }
        public DateTime DateConversation { get; set; }
        public Int64 IdStudent { get; set; }
        public string? EssenceOfConversation { get; set; } = "";
        public string? AcceptedDecision { get; set; } = "";
    }
}
