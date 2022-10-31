using Microsoft.AspNetCore.Mvc;

namespace TakeFood.StoreService.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
        public string GetId()
        {
            String id = HttpContext.Items["Id"]!.ToString()!;
            return id;
        }
    }
}
