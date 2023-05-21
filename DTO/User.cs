using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTO
{
    [Table("User")]
    public class User
    {
        [Key]
        public Int16 IdUser { get; set; }
        public string UserName { get; set; } = "";
    }
}
