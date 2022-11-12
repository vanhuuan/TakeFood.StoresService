
using StoreService.Model.Entities.Food;
using TakeFood.StoreService.ViewModel.Dtos.Food;

namespace StoreService.Service
{
    public interface IFoodService
    {
        Task CreateFood(string StoreID, CreateFoodDto food);
        Task UpdateFood(string FoodID, CreateFoodDto foodUpdate);
        Task<Boolean> UpdateState(string FoodID, bool state);
        Task<List<FoodView>> GetAllFoodsByStoreID(string StoreID);
        Task<List<FoodView>> GetAllFoodsByCategory(string CategoryID);
        Task<FoodViewMobile> GetFoodByID(string FoodID);
    }
}
