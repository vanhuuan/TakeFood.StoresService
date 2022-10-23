using Microsoft.AspNetCore.Mvc;
using StoreService.Service;
using TakeFood.StoreService.Service;
using TakeFood.StoreService.ViewModel.Dtos.Address;

namespace TakeFood.StoreService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController:BaseController
    {
        public readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task CreateStoreAddress(StoreAddressDto addressStore)
        {
            AddressDto address = new AddressDto()
            {
                address = "Tỉnh/TP: " + addressStore.province + ", Quận/Huyện: " + addressStore.district + ", Xã/Phường: " + addressStore.town,
                lat = addressStore.lat,
                lng = addressStore.lng,
            };
            await _addressService.CreateAddress(address);
        }

        [HttpDelete]
        public async Task DeleteAddress(string id)
        {
            await _addressService.DeleteAddress(id);
        }
    }
}
