using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTO
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public Int64 IdGroup { get; set; }
        public Int64 IdCurator { get; set; }
        public string? NameGroup { get; set; }
        public Curator Curator { get; set; }
    }
}
