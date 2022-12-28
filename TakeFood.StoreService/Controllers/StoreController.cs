using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using System.ComponentModel.DataAnnotations;
using TakeFood.StoreService.Controllers;
using TakeFood.StoreService.ViewModel.Dtos.Store;


namespace StoreService.Controllers
{
    public class StoreController : BaseController
    {
        private IStoreService _StoreService;

        public StoreController(IStoreService StoreService)
        {
            _StoreService = StoreService;
        }

        [HttpPost]
        [Route("CreateStore")]
        public async Task<IActionResult> CreateStoreAsync(string OwnerID, [FromBody] CreateStoreDto store)
        {
            try
            {
                if (await _StoreService.GetStoreByOwnerID(OwnerID) == null)
                {
                    await _StoreService.CreateStore(OwnerID, store);
                    return Ok();
                }
                else
                {
                    return BadRequest("User đã có cửa hàng");
                }
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("GetStoreByOwner")]
        public async Task<JsonResult> GetStoreByOwnerID(string ownerID)
        {
            StoreOwnerDto store = await _StoreService.GetStoreByOwnerID(ownerID);
            try
            {
                var result = new JsonResult(store);
                return result;
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }

        }

        [HttpPost]
        [Route("GetNearBy")]
        public async Task<ActionResult<List<CardStoreDto>>> GetStoreNearByAsync([FromBody] GetStoreNearByDto dto)
        {
            try
            {
                var list = await _StoreService.GetStoreNearByAsync(dto);
                return list;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("FilterNearByWithCategory")]
        public async Task<IActionResult> FilterStoreNearByAsync([FromBody] FilterStoreByCategoryId dto)
        {
            try
            {
                var list = await _StoreService.FilterStoreNearByAsync(dto);
                return Ok(list);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("FindStore")]
        public async Task<IActionResult> FindStoreAsync([Required] string name, [Required] double lat, [Required] double lng, [Required] int start)
        {
            try
            {
                var list = await _StoreService.FindStoreByNameAsync(name, lat, lng, start);

                return Ok(list);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("GetStore")]
        public async Task<IActionResult> GetStoreById([Required] string storeId, [Required] double lat, [Required] double lng)
        {
            try
            {
                var store = await _StoreService.GetStoreDetailAsync(storeId, lat, lng);

                return Ok(store);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("GetPagingStore")]
        public async Task<IActionResult> GetPagingStore(GetPagingStoreDto dto)
        {
            try
            {
                var store = await _StoreService.GetStorePaging(dto);
                return Ok(store);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Route("GetRegisterDetailStore")]
        public async Task<IActionResult> GetStoreRegisterDetail([Required] string storeId)
        {
            try
            {
                var store = await _StoreService.GetStoreRegisterDetailAsync(storeId);
                return Ok(store);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        [Route("ActiveStore")]
        public async Task<IActionResult> ActiveStore([Required] string storeId)
        {
            try
            {
                await _StoreService.ActiveStoreAsync(storeId);
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut]
        [Route("DeActiveStore")]
        public async Task<IActionResult> DeActiveStore([Required] string storeId)
        {
            try
            {
                await _StoreService.DeActiveStoreAsync(storeId);
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        // [Authorize(roles: Roles.Admin)]
        [Route("InsertStore")]
        public async Task<IActionResult> InsertStoreAsync()
        {
            await _StoreService.InertCrawlData();

            return Ok();
        }

        [HttpGet]
        // [Authorize(roles: Roles.Admin)]
        [Route("InsertMenu")]
        public async Task<IActionResult> InsertMenuStoreAsync()
        {
            await _StoreService.InertMenuCrawlDataAsync();

            return Ok();
        }
    }
}
