using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using TakeFood.StoreService.Controllers;
using TakeFood.StoreService.ViewModel.Dtos.Food;

namespace StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : BaseController
    {
        private IFoodService _FoodService;

        public FoodController(IFoodService foodService)
        {
            _FoodService = foodService;
        }

        [HttpPost("{StoreID}")]
        public async Task<IActionResult> CreateFood(string StoreID, CreateFoodDto food)
        {
            await _FoodService.CreateFood(StoreID, food);

            return Ok(food);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFood(string FoodID, CreateFoodDto foodUpdate)
        {
            await _FoodService.UpdateFood(FoodID, foodUpdate);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFood(string id)
        {
            await _FoodService.DeleteFood(id);

            return Ok();
        }

        [HttpGet("GetAllFoodByStore/{StoreID}")]

        public async Task<List<FoodView>> getAllFoodByStore(string StoreID)
        {
            return await _FoodService.GetAllFoodsByStoreID(StoreID);
        }

        [HttpGet("GetAllFoodByCategory/{CategoryID}")]

        public async Task<List<FoodView>> GetAllFoodByCategory(string CategoryID)
        {
            return await _FoodService.GetAllFoodsByCategory(CategoryID);
        }

        [HttpGet("GetFoodViewMobile/{FoodID}")]

        public async Task<JsonResult> GetFoodViewMobile(string FoodID)
        {
            return new JsonResult(await _FoodService.GetFoodByID(FoodID));
        }
    }
}
