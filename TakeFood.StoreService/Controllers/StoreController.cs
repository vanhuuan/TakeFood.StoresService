﻿using Microsoft.AspNetCore.Mvc;
using StoreService.Middleware;
using StoreService.Service;
using System.ComponentModel.DataAnnotations;
using TakeFood.StoreService.Controllers;
using TakeFood.StoreService.Model.Entities;
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
            await _StoreService.CreateStore(OwnerID, store);

            return Ok();
        }

        [HttpPost]
        [Authorize]
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
                throw err;
            }
        }

        [HttpPost]
        [Authorize]
        [Route("FilterNearByWithCategory")]
        public async Task<IActionResult> FilterStoreNearByAsync([FromBody] FilterStoreByCategoryId dto)
        {
            try
            {
                var list = await _StoreService.FilterStoreNearByAsync(dto);
                return Ok(list); ;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet]
        [Authorize]
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
        [Authorize(roles: Roles.Admin)]
        [Route("InsertStore")]
        public async Task<IActionResult> InsertStoreAsync()
        {
            await _StoreService.InertCrawlData();

            return Ok();
        }

        [HttpGet]
        [Authorize(roles: Roles.Admin)]
        [Route("InsertMenu")]
        public async Task<IActionResult> InsertMenuStoreAsync()
        {
            await _StoreService.InertMenuCrawlDataAsync();

            return Ok();
        }
    }
}
