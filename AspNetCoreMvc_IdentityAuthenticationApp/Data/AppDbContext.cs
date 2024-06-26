using AspNetCoreMvc_IdentityAuthenticationApp.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc_IdentityAuthenticationApp.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
