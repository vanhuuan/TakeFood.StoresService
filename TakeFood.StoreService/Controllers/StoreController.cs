using Microsoft.AspNetCore.Mvc;
using StoreService.Model.Entities.Store;
using StoreService.Service;
using TakeFood.StoreService.Controllers;
using TakeFood.StoreService.ViewModel.Dtos.Store;

namespace StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : BaseController
    {
        private IStoreService _StoreService;

        public StoreController(IStoreService StoreService)
        {
            _StoreService = StoreService;
        }

        [HttpPost]
        public async Task<IActionResult> createStore(string OwnerID, CreateStoreDto store)
        {
            await _StoreService.CreateStore(OwnerID, store);

            return Ok();
        }
    }
}
