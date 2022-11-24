namespace TakeFood.StoreService.ViewModel.Dtos.Store;

public class StorePagingRespone
{
    public int Total { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public List<StoreCardDto> Cards { get; set; }
}

public class StoreCardDto
{
    public int Id { get; set; }
    public int Stt { get; set; }
    public string StoreId { get; set; }
    public string Name { get; set; }
    public string OwnerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
}


