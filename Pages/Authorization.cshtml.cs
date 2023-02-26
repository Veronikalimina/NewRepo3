using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication1.Configs;
using WebApplication1.DTO;

namespace WebApplication1.Pages
{
    public class AuthorizationModel : PageModel
    {
        public string Error { get; set; } = "";
        public void OnGet()
        {
        }
        private readonly ApplicationContext _context;

        public AuthorizationModel(ApplicationContext context)
        {
            _context = context;
        }
        public void OnPost(string username, string password)
        {
            var Authentication = _context.Authentications.FirstOrDefault(p => p.Login == username && p.Password == password);
            if (Authentication == null)
            {
                Error = "Ошибка авторизации";
            }
            else
            {
                CreateToken(username);
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
