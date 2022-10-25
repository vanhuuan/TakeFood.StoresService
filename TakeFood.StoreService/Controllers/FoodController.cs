using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using TakeFood.StoreService.Controllers;
using StoreService.Model.Entities.Food;
using TakeFood.StoreService.ViewModel.Dtos.Food;

namespace StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController:BaseController
    {
        private IFoodService _FoodService;

        public FoodController(IFoodService foodService)
        {
            _FoodService = foodService;
        }

        [HttpPost("{StoreID}")]
        public async Task<IActionResult> createFood(string StoreID, CreateFoodDto food)
        {
            await _FoodService.CreateFood(StoreID, food);

            return Ok(food);
        }
    }
}
