
using StoreService.Model.Entities.Food;
using StoreService.Model.Repository;

namespace StoreService.Service.Implement
{
    public class FoodService : IFoodService
    {
        private readonly IMongoRepository<Food> foodRepository;
        public async Task CreateFood(Food food)
        {
            await foodRepository.InsertAsync(food);
        }
    }
}
