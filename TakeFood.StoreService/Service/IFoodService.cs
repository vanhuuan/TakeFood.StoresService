
using StoreService.Model.Entities.Food;

namespace StoreService.Service
{
    public interface IFoodService
    {
        Task CreateFood(Food food);
    }
}
