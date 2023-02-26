using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTO
{
    [Table("Authentication")]
    public class Authentication
    {
        [Key]
        public Int64 IdAuthentication { get; set; }
        public Int64 IdKyratora { get; set; }
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public Int16 IdUser { get; set; }
    }
}
