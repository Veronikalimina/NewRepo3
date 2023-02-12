using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication1.Configs;

namespace WebApplication1.Pages
{
    public class AuthorizationModel : PageModel
    {
        public string Token { get; set; }
        public void OnGet()
        {
        }

        public void OnPost(string username, string password)
        {
            
            if (username == "123" && password == "123")
            {
                Token = CreateToken(username);
                 

            }
            
            
        }
        private string CreateToken(string username)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
// создаем JWT-токен
            //var jwt = new JwtSecurityToken(
            //        issuer: AuthOptions.ISSUER,
            //        audience: AuthOptions.AUDIENCE,
            //        claims: claims,
            //        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
            //        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
// установка аутентификационных куки
            SignIn(new ClaimsPrincipal(claimsIdentity), CookieAuthenticationDefaults.AuthenticationScheme);
            //return new JwtSecurityTokenHandler().WriteToken(jwt);
            return "Авторизация пройдена";
        }
    }
}
