using Microsoft.AspNetCore.Mvc;
using StoreService.Service;

namespace TakeFood.StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<Boolean> HasStore(string userID)
        {
            return await _userService.HasStore(userID);
        }
    }
}
