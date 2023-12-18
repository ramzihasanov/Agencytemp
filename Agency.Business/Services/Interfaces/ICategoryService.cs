using Agency.Core.Models;
namespace Agency.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task Delete(int id);
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        Task UpdateAsync(Category category);
    }
}
