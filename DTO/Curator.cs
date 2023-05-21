using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTO
{
    [Table("Curator")]
    public class Curator
    {
        [Key]
        public Int64 IdCurator { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
    }
   
}
