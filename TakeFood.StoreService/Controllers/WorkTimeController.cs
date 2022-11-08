using Microsoft.AspNetCore.Mvc;
using TakeFood.StoreService.Service;
using TakeFood.StoreService.ViewModel.Dtos.WorkTime;

namespace TakeFood.StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkTimeController:BaseController
    {
        private readonly IWorkTime workTimeService;

        public WorkTimeController(IWorkTime workTimeService)
        {
            this.workTimeService = workTimeService;
        }

        [HttpGet]
        public async Task<JsonResult> GetWorkTime(string storeID)
        {
            try
            {
                var workTime = await workTimeService.GetWorkTime(storeID);
                return new JsonResult(workTime);
            }catch(Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkTime(WorkTimeDto workTime)
        {
            try
            {
                await workTimeService.createWorkTime(workTime);
                return Ok(workTime);
            }
            catch
            {
                return BadRequest("Có lỗi khi thực hiện thao tác này");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkTime(WorkTimeDto workTime)
        {
            try
            {
                await workTimeService.updateWorkTime(workTime);
                return Ok(workTime);
            }
            catch
            {
                return BadRequest("Có lỗi khi thực hiện thao tác này");
            }
        }
    }
}
