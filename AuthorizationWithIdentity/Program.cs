using AuthorizationWithIdentity.CustomValidation;
using AuthorizationWithIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Mvc ile ilgili bileþenleri kurar.
builder.Services.AddDbContext<AppIdentityDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
    });

   

});

//password validation,validatorler
builder.Services.AddIdentity<AppUser,AppRole>(opt=>
{
    opt.User.RequireUniqueEmail = true;
    opt.User.AllowedUserNameCharacters = "qwertyuýopðüasdfghjklþizxcvbnmöç_-+$ASDFGHJKLÞÝQWERTYUIOPÐÜZXCVBNMÖÇ";
    opt.Password.RequiredLength = 4;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireLowercase= false;
    opt.Password.RequireDigit = false;
   
}).AddPasswordValidator<CustomPasswordValidator>().AddErrorDescriber<CustomIdentityErrorDescriber>().
AddUserValidator<CustomUserValidator>().AddEntityFrameworkStores<AppIdentityDbContext>();


CookieBuilder cookieBuilder = new CookieBuilder();
cookieBuilder.Name = "MyBlog";
cookieBuilder.HttpOnly = false;
cookieBuilder.SameSite = SameSiteMode.Lax; // siteler arasý istekle ilgili güvenlik.
cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;// always sadece httpsden,none ayarsýz, diðer nerden geldiyse gönderir

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/Home/LogIn");// kýsýtlý sayfaya eriþmeye çalýþýrsa logine yönlenir
    opt.LogoutPath = new PathString("/Home/LogOut");
    opt.Cookie = cookieBuilder;
    opt.SlidingExpiration = true; // 30 günden sonra giriþ yaparsa cookie ömrü uzar.
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);// sýrasý önemli
});


var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );// Default Route yapýlanmasý

app.Run();
