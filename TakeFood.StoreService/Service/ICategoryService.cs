using StoreService.ViewModel.Dtos.Category;

namespace StoreService.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<List<CategoryDto>> GetAllStoreCategories();
        Task<CategoryDto> GetCategoryById(String id);
        Task CreateCategory(CategoryDto category);
        Task UpdateCategory(string id, CategoryDto category);
        Task DeleteCategory(String id);
    }
}
