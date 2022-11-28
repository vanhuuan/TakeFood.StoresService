using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using System.ComponentModel.DataAnnotations;
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

        [HttpPut("UpdateFood")]
        public async Task<IActionResult> UpdateFood(string FoodID, CreateFoodDto foodUpdate)
        {
            await _FoodService.UpdateFood(FoodID, foodUpdate);

            return Ok();
        }

        [HttpPut("UpdateState")]
        public async Task<IActionResult> UpdateState(string id, bool state)
        {
            if (await _FoodService.UpdateState(id, state)) return Ok();

            return BadRequest("không tồn tại món này");
        }

        [HttpGet("GetAllFoodByStore")]
        public async Task<IActionResult> getAllFoodByStore([Required] string StoreID)
        {
            try
            {
                var foodList = await _FoodService.GetAllFoodsByStoreID(StoreID);
                return Ok(foodList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllFoodByCategory/{CategoryID}")]
        public async Task<List<FoodView>> GetAllFoodByCategory(string CategoryID)
        {
            return await _FoodService.GetAllFoodsByCategory(CategoryID);
        }

        [HttpGet("GetFoodViewMobile")]
        public async Task<JsonResult> GetFoodViewMobile([Required] string FoodID)
        {
            try
            {
                FoodViewMobile fMoble = await _FoodService.GetFoodByID(FoodID);
                var food = new JsonResult(fMoble);
                return food;
            }
            catch (Exception e)
            {
                JsonResult error = new(e.Message);
                return error;
            }
        }
    }
}
