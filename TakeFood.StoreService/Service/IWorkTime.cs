using TakeFood.StoreService.ViewModel.Dtos.WorkTime;

namespace TakeFood.StoreService.Service
{
    public interface IWorkTime
    {
        Task<WorkTimeDto> GetWorkTime(string storeID);
        Task createWorkTime(WorkTimeDto workTimeDto);
        Task updateWorkTime(WorkTimeDto workTimeDto);
    }
}
