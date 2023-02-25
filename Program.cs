using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Configs;
using WebApplication1;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // получаем строку подключения из файла конфигурации
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");

        // добавляем контекст ApplicationContext в качестве сервиса в приложение
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(options => options.LoginPath = "/Authorization");

        builder.Services.AddAuthorization();

        builder.Services.AddRazorPages();

        builder.Services.AddMvc().AddRazorPagesOptions(options =>
        {
            options.Conventions.AuthorizeFolder("/");
            options.Conventions.AllowAnonymousToPage("/Authorization");
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();   // добавление middleware аутентификации 
        app.UseAuthorization();   // добавление middleware авторизации 

        app.MapRazorPages();

        app.Run();
    }
}