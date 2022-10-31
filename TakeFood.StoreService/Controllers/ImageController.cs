/*using Microsoft.AspNetCore.Mvc;
using TakeFood.StoreService.Service;
using TakeFood.StoreService.ViewModel.Dtos.Image;

namespace TakeFood.StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : BaseController
    {
        private readonly IImageService Imageservice;

        public ImageController(IImageService imageservice)
        {
            Imageservice = imageservice;
        }

        [HttpPost]
        public async Task<IActionResult> createImage(string StoreID, string categoryID, ImageDto image)
        {
            await Imageservice.CreateImage(StoreID, categoryID, image);

            return Ok(image);
        }
    }
}
*/