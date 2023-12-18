using Agency.Core.Models;
using Agency.Core.Repositories.Interfaces;
using Agency.Data.DAL;

namespace Agency.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
