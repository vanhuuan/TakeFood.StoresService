using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using TakeFood.StoreService.Controllers;
using StoreService.Model.Entities.Food;

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

        [HttpPost]
        public async Task<IActionResult> createFood(Food food)
        {
            await _FoodService.CreateFood(food);

            return Ok(food);
        }
    }
}
