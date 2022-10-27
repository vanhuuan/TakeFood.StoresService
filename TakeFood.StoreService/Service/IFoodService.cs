
using StoreService.Model.Entities.Food;
using TakeFood.StoreService.ViewModel.Dtos.Food;

namespace StoreService.Service
{
    public interface IFoodService
    {
        Task CreateFood(string StoreID, CreateFoodDto food);
        Task UpdateFood(string FoodID, CreateFoodDto foodUpdate);
        Task DeleteFood(string FoodID);
    }
}
