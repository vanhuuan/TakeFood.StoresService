
using StoreService.Model.Entities.Address;
using StoreService.Model.Entities.Store;
using StoreService.Model.Repository;
using TakeFood.StoreService.Service;
using TakeFood.StoreService.ViewModel.Dtos.Image;
using TakeFood.StoreService.ViewModel.Dtos.Store;

namespace StoreService.Service.Implement
{
    public class StoreService : IStoreService
    {
        private readonly IMongoRepository<Store> storeRepository;
        private readonly IMongoRepository<Address> addressRepository;
        private readonly IImageService imageService;
        public StoreService(IMongoRepository<Store> storeRepository, IMongoRepository<Address> addressRepository, IImageService imageService)
        {
            this.storeRepository = storeRepository;
            this.addressRepository = addressRepository;
            this.imageService = imageService;
        }

        public async Task CreateStore(string ownerID, CreateStoreDto store)
        {
            Address address = new Address()
            {
                Information = "Tỉnh/TP: " + store.StoreAddress.province + ", Quân/Huyện: " + store.StoreAddress.district + ", Xã/Phường: " + store.StoreAddress.town,
            };
            Store _store = new Store()
            {
                Name = store.StoreName,
                AddressId = (await addressRepository.InsertAsync(address)).Id,
                PhoneNumber = store.StorePhone,
                State = "Active",
                OwnerId = ownerID,
                SumStar = 0,
                NumReiview = 0,
                TaxId = store.TaxID,
            };
            await storeRepository.InsertAsync(_store);
            await InsertImage(_store.Id, "6354d739d64447e2509cb9fb", store.urlStoreImage);
            await InsertImage(_store.Id, "6354d7e9d64447e2509cb9fc", store.urlKitchenImage);
            await InsertImage(_store.Id, "6354d802d64447e2509cb9fd", store.urlMenuImage);
            await InsertImage(_store.Id, "6354d80dd64447e2509cb9fe", store.urlFontCmndImage);
            await InsertImage(_store.Id, "6354d818d64447e2509cb9ff", store.urlBackCmndImage);
            await InsertImage(_store.Id, "6354d82cd64447e2509cba00", store.urlLicenseImage);
        }

        public List<Store> getAllStores()
        {
            return storeRepository.GetAll().ToList();
        }

        private async Task InsertImage(string storeID, string categoryID, string url)
        {
            ImageDto image = new ImageDto()
            {
                Url = url,
            };
            await imageService.CreateImage(storeID, categoryID, image);
        }
    }
}
