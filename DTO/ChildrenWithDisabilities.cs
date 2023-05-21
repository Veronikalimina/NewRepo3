using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class ChildrenWithDisabilities
    {
        [Key]
        public Int64 IdEntryChildrenWithDisabilities { get; set; }
        public Int64 IdStudent { get; set; }
    }
}
