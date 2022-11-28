using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using StoreService.ViewModel.Dtos.Category;
using TakeFood.StoreService.Controllers;
using TakeFood.StoreService.Model.Entities.Category;

namespace StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        public readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> createCategory(CreateCategoryDto category)
        {
            await _categoryService.CreateCategory(category);

            return Ok();
        }

        [HttpGet]
        public async Task<List<CategoryDto>> getAllCategory()
        {
            return await _categoryService.GetAllCategories();
        }

        [HttpGet]
        [Route("GetStoreCategory")]
        public async Task<JsonResult> getAllStoreCategory()
        {
            try
            {
                return new JsonResult(await _categoryService.GetAllStoreCategories());
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpGet]
        [Route("GetFoodCategory")]
        public async Task<JsonResult> getAllFoodCategory()
        {
            try
            {
                return new JsonResult(await _categoryService.GetAllFoodCategories());
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }

        }

        [HttpGet("{id}")]
        public async Task<CategoryDto> getCategoryById(string id)
        {
            return await _categoryService.GetCategoryById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CategoryDto category)
        {
            var _category = await _categoryService.GetCategoryById(id);
            if (_category is null) return NotFound();

            await _categoryService.UpdateCategory(id, category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null) return BadRequest();

            await _categoryService.DeleteCategory(id);

            return Ok();
        }
    }
}
