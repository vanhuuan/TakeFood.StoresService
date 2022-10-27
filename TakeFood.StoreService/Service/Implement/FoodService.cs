
using StoreService.Model.Entities.Food;
using StoreService.Model.Repository;
using TakeFood.StoreService.ViewModel.Dtos.Food;

namespace StoreService.Service.Implement
{
    public class FoodService : IFoodService
    {
        private readonly IMongoRepository<Food> _foodRepository;
        private readonly IMongoRepository<FoodTopping> _foodToppingRepository;

        public FoodService(IMongoRepository<Food> foodRepository, IMongoRepository<FoodTopping> foodToppingRepository)
        {
            this._foodRepository = foodRepository;
            _foodToppingRepository = foodToppingRepository;
        }

        public async Task CreateFood(string StoreID, CreateFoodDto food)
        {
            Food f = new Food()
            {
                Name = food.Name,
                Price = food.Price,
                StoreId = StoreID,
                CategoriesID = food.CategoriesID,
                ImgUrl = food.urlImage,
                Description = food.Descript,
                State = food.State
            };

            Food temp = await _foodRepository.InsertAsync(f);

            foreach (var i in food.ListTopping)
            {
                FoodTopping foodTopping = new FoodTopping()
                {
                    ToppingId = i.ID,
                    FoodId = temp.Id
                };
                await _foodToppingRepository.InsertAsync(foodTopping);
            }
        }

        public async Task DeleteFood(string FoodID)
        {
            Food food = await _foodRepository.FindOneAsync(x => x.Id == FoodID);

            food.State = false;
            await _foodRepository.UpdateAsync(food);
        }

        public async Task UpdateFood(string FoodID, CreateFoodDto foodUpdate)
        {
            Food food = await _foodRepository.FindOneAsync(x => x.Id == FoodID);
            food.Name = foodUpdate.Name;
            food.Price = foodUpdate.Price;
            food.Description = foodUpdate.Descript;
            food.ImgUrl = foodUpdate.urlImage;
            food.CategoriesID = foodUpdate.CategoriesID;
            await _foodRepository.UpdateAsync(food);

            await _foodToppingRepository.RemoveManyAsync(x => x.FoodId == FoodID);

            foreach (var i in foodUpdate.ListTopping)
            {
                FoodTopping foodTopping = new FoodTopping()
                {
                    ToppingId = i.ID,
                    FoodId = FoodID
                };
                await _foodToppingRepository.InsertAsync(foodTopping);
            }
        }
    }
}
