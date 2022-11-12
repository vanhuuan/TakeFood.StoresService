using StoreService.ViewModel.Dtos.Category;
using TakeFood.StoreService.Model.Entities.Category;

namespace StoreService.Service
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<List<CategoryDto>> GetAllStoreCategories();
        Task<List<CategoryDto>> GetAllFoodCategories();
        Task<CategoryDto> GetCategoryById(String id);
        Task CreateCategory(CreateCategoryDto category);
        Task UpdateCategory(string id, CategoryDto category);
        Task DeleteCategory(String id);
    }
}
