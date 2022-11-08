using StoreService.Model.Entities.Store;
using StoreService.Model.Entities.WorkTime;
using StoreService.Model.Repository;
using TakeFood.StoreService.ViewModel.Dtos.WorkTime;

namespace TakeFood.StoreService.Service.Implement
{
    public class WorkTimeService : IWorkTime
    {
        private readonly IMongoRepository<WorkTime> _workTimeRepository;
        private readonly IMongoRepository<Store> _storeRepository;

        public WorkTimeService(IMongoRepository<WorkTime> workTimeRepository, IMongoRepository<Store> storeRepository)
        {
            _workTimeRepository = workTimeRepository;
            _storeRepository = storeRepository;
        }

        public async Task createWorkTime(WorkTimeDto workTimeDto)
        {
            WorkTime workTime = new()
            {
                Storeid = workTimeDto.storeID,
                OpenHour = workTimeDto.openHour,
                CloseHour = workTimeDto.closeHour,
                StartDay = workTimeDto.startDate,
                EndDay = workTimeDto.endDate
            };
            await _workTimeRepository.InsertAsync(workTime);
        }

        public async Task<WorkTimeDto> GetWorkTime(string storeID)
        {
            Store store = await _storeRepository.FindByIdAsync(storeID);
            WorkTimeDto workTimeDto = new();
            if(store != null)
            {
                WorkTime workTime = await _workTimeRepository.FindOneAsync(x => x.Storeid == store.Id);
                workTimeDto.startDate = workTime != null ? workTime.StartDay : store.CreatedDate;
                workTimeDto.endDate = workTime != null ? workTime.EndDay : new DateTime(2022, 12, 31);
                workTimeDto.openHour = workTime != null ? workTime.OpenHour : 7;
                workTimeDto.closeHour = workTime != null ? workTime.CloseHour : 20;
                workTimeDto.storeID = storeID;
            }
            else
            {
                throw new NullReferenceException("Không tồn tại cửa hàng này");
            }
            return workTimeDto;
        }

        public async Task updateWorkTime(WorkTimeDto workTimeDto)
        {
            WorkTime workTime = await _workTimeRepository.FindOneAsync(x => x.Storeid == workTimeDto.storeID);
            workTime.OpenHour = workTimeDto.openHour;
            workTime.CloseHour = workTimeDto.closeHour;
            workTime.StartDay = workTimeDto.startDate;
            workTime.EndDay = workTimeDto.endDate;

            await _workTimeRepository.UpdateAsync(workTime);
        }
    }
}
