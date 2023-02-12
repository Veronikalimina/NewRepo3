using Microsoft.AspNetCore.Authentication;
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
        public string Error { get; set; }
        public void OnGet()
        {
        }

        public void OnPost(string username, string password)
        {
            
            if (username == "123" && password == "123")
            {
                CreateToken(username);
            }
            else
            {
                Error = "Ошибка авторизации";
            }
            
            
        }
        private void CreateToken(string username)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
