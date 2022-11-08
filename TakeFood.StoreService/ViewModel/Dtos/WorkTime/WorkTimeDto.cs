namespace TakeFood.StoreService.ViewModel.Dtos.WorkTime
{
    public class WorkTimeDto
    {
        public string storeID { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int openHour { get; set; }
        public int closeHour { get; set; }
    }
}
