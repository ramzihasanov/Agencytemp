using Agency.Core.Models;
using Agency.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agency.ViewService
{
    public class LayoutService
    { 

        private readonly AppDbContext _context;
    private readonly UserManager<AppUser> userManager;
    private readonly IHttpContextAccessor httpContextAccessor;

    public LayoutService(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        this.userManager = userManager;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<Setting>> GetData()
    {
        var settings = _context.Settings.ToList();
        return settings;
    }

   
}
}
