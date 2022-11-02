using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using TakeFood.StoreService.Controllers;
using StoreService.Model.Entities.Food;
using TakeFood.StoreService.ViewModel.Dtos.Food;
using TakeFood.StoreService.Model.Entities;
using StoreService.Middleware;
using System.ComponentModel.DataAnnotations;

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
        [Authorize(roles: Roles.ShopeOwner)]
        public async Task<IActionResult> CreateFood(string StoreID, CreateFoodDto food)
        {
            await _FoodService.CreateFood(StoreID, food);

            return Ok(food);
        }

        [HttpPut]
        [Authorize(roles: Roles.ShopeOwner)]
        public async Task<IActionResult> UpdateFood(string FoodID, CreateFoodDto foodUpdate)
        {
            await _FoodService.UpdateFood(FoodID, foodUpdate);

            return Ok();
        }

        [HttpDelete]
        [Authorize(roles: Roles.ShopeOwner)]
        public async Task<IActionResult> DeleteFood(string id)
        {
            await _FoodService.DeleteFood(id);

            return Ok();
        }

        [HttpGet("GetAllFoodByStore")]
        [Authorize]
        public async Task<IActionResult> getAllFoodByStore([Required]string StoreID)
        {
            try
            {
                var foodList = await _FoodService.GetAllFoodsByStoreID(StoreID);
                return Ok(foodList);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllFoodByCategory/{CategoryID}")]
        [Authorize]
        public async Task<List<FoodView>> GetAllFoodByCategory(string CategoryID)
        {
            return await _FoodService.GetAllFoodsByCategory(CategoryID);
        }

        [HttpGet("GetFoodViewMobile")]
        [Authorize]
        public async Task<IActionResult> GetFoodViewMobile([Required]string FoodID)
        {
            try
            {
                FoodViewMobile fMoble = await _FoodService.GetFoodByID(FoodID);
                var food = new JsonResult(fMoble);
                return Ok(food);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
