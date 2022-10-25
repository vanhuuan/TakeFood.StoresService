using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TakeFood.StoreService.Service;
using TakeFood.StoreService.ViewModel.Dtos.Topping;

namespace TakeFood.StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToppingController : BaseController
    {
        public readonly IToppingService _toppingService;

        public ToppingController(IToppingService toppingService)
        {
            _toppingService = toppingService;
        }

        [HttpPost("{StoreID}")]
        public async Task<IActionResult> CreateTopping(string StoreID, CreateToppingDto createToppingDto)
        {
            await _toppingService.CreateTopping(StoreID, createToppingDto);

            return Ok();
        }

        [HttpGet("/GetAllTopping/{StoreID}")]
        public async Task<List<ToppingViewDto>> getAllToppping(string StoreID)
        {
            return await _toppingService.GetAllToppingByStoreID(StoreID, "");
        }

        [HttpGet("/GetToppingActive/{StoreID}")]
        public async Task<List<ToppingViewDto>> getAllToppingActive(string StoreID)
        {
            return await _toppingService.GetAllToppingByStoreID(StoreID, "Active");
        }

        [HttpGet("/GetToppingDeActive/{StoreID}")]
        public async Task<List<ToppingViewDto>> getAllToppingDeActive(string StoreID)
        {
            return await _toppingService.GetAllToppingByStoreID(StoreID, "DeActive");
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, CreateToppingDto updateTopping)
        {
            await _toppingService.UpdateTopping(id, updateTopping);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            await _toppingService.DeleteTopping(id);

            return Ok();
        }
    }
}
