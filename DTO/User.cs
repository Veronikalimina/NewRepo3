using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTO
{
    [Table("User")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string UserName { get; set; } = "";
    }
}
