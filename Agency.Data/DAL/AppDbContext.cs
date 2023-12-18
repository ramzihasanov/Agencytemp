using Agency.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Agency.Data.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Setting > Settings { get; set; }
        public DbSet <Portfolio> Portfolios { get; set; }
       public  DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
