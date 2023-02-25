namespace WebApplication1.DTO
{
    public class Authentication
    {
        public int IdAuthentication { get; set; }
        public int IdKyratora { get; set; }
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public int IdUser { get; set; }
    }
}
