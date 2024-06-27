using AspNetCoreMvc_IdentityAuthenticationApp.Data;
using AspNetCoreMvc_IdentityAuthenticationApp.Identity.Models;
using System.Numerics;

namespace AspNetCoreMvc_IdentityAuthenticationApp.Extensions
{
    public static class StartExtension
    {
        public static void AddIdentityExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>
                (opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireDigit = false;

                    //opt.User.RequireUniqueEmail = true;  //Aynı email adresinin girilmesini izinverilmez
                    //opt.User.AllowedUserNameCharacters = "abcçdefgğhiıjklmnoöprsştuüvyz"; //kullanıcı adı girilirken izin verilen karakterler.
                
                    opt.Lockout.MaxFailedAccessAttempts = 3;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default = 5
                }).AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                //opt.AccessDeniedPath = new PathString("/Account/Accessdenied");
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true; //10 dk dolmadan yeniden login olursa süre baştan başlar.,

                opt.Cookie = new CookieBuilder()
                {
                    Name = "Identity.App.Cookie",
                    HttpOnly = true,
                };
            });







        }
    }
}
