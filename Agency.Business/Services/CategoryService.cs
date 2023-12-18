using Agency.Business.Services.Interfaces;
using Agency.Core.Models;
using Agency.Core.Repositories.Interfaces;
namespace Agency.Business.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(Category entity)
    {
            if (categoryRepository.Table.Any(x => x.Name == entity.Name))
                throw new Exception();
        await categoryRepository.CreateAsync(entity);
        await categoryRepository.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await categoryRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
        if (entity == null) throw new Exception();
        entity.IsDeleted = true;
        await categoryRepository.CommitAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var entity = await categoryRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity is null) throw new Exception();
        return entity;
    }

    public async Task UpdateAsync(Category cat)
    {
        var existEntity = await categoryRepository.GetByIdAsync(x => x.Id == cat.Id);
            if (existEntity is null) throw new Exception();
        existEntity.Name = cat.Name;
        await categoryRepository.CommitAsync();
    }
}
}