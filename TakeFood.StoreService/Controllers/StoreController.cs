using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateStoreAsync(string OwnerID, CreateStoreDto store)
        {
            await _StoreService.CreateStore(OwnerID, store);

            return Ok();
        }

        [HttpPost]
        [Authorize("User")]
        [Route("GetNearBy")]
        public async Task<ActionResult<IList<CardStoreDto>>> GetStoreNearByAsync(GetStoreNearByDto dto)
        {
            try
            {
                return await _StoreService.GetStoreNearByAsync(dto);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize("User")]
        [Route("FilterNearByWithCategory")]
        public async Task<ActionResult<IList<CardStoreDto>>> FilterStoreNearByAsync(FilterStoreByCategoryId dto)
        {
            try
            {
                return await _StoreService.FilterStoreNearByAsync(dto);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("InsertStore")]
        public async Task<IActionResult> InsertStoreAsync()
        {
            await _StoreService.InertCrawlData();

            return Ok();
        }

        [HttpGet]
        [Route("InsertMenu")]
        public async Task<IActionResult> InsertMenuStoreAsync()
        {
            await _StoreService.InertMenuCrawlDataAsync();

            return Ok();
        }
    }
}
