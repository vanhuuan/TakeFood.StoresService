using MongoDB.Driver.Linq;
using StoreService.Model.Entities.Address;
using StoreService.Model.Entities.Store;
using StoreService.Model.Repository;
using TakeFood.StoreService.Service;
using TakeFood.StoreService.Utilities.Helper;
using TakeFood.StoreService.ViewModel.Dtos.Image;
using TakeFood.StoreService.ViewModel.Dtos.Store;

namespace StoreService.Service.Implement
{
    public class StoreService : IStoreService
    {
        private readonly IMongoRepository<Store> storeRepository;
        private readonly IMongoRepository<Address> addressRepository;
        private readonly IImageService imageService;
        private readonly IMongoRepository<StoreCategory> storeCateRepository;
        public StoreService(IMongoRepository<Store> storeRepository, IMongoRepository<Address> addressRepository
            , IImageService imageService, IMongoRepository<StoreCategory> storeCateRepository)
        {
            this.storeRepository = storeRepository;
            this.addressRepository = addressRepository;
            this.imageService = imageService;
            this.storeCateRepository = storeCateRepository;
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

            foreach (var category in store.Categories)
            {
                StoreCategory storeCategory = new StoreCategory()
                {
                    CategoryId = category.CategoryId,
                    StoreId = _store.Id
                };
                await storeCateRepository.InsertAsync(storeCategory);
            }

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

        public async Task<List<CardStoreDto>> GetStoreNearByAsync(GetStoreNearByDto getStoreNearByDto)
        {
            var box = MapCoordinates.GetBoundingBox(new MapPoint()
            {
                Latitude = getStoreNearByDto.Lat,
                Longitude = getStoreNearByDto.Lng
            }, getStoreNearByDto.RadiusOut);
            IList<Address> storeAddress;
            IEnumerable<string> ids;
            storeAddress = await addressRepository.FindAsync(x => x.AddressType == "Store" && box.MinPoint.Latitude <= x.Lat && x.Lng <= box.MaxPoint.Latitude && box.MinPoint.Longitude <= x.Lng && x.Lng <= box.MinPoint.Latitude);
            if (getStoreNearByDto.RadiusIn != 0)
            {
                var inBox = MapCoordinates.GetBoundingBox(new MapPoint()
                {
                    Latitude = getStoreNearByDto.Lat,
                    Longitude = getStoreNearByDto.Lng
                }, getStoreNearByDto.RadiusIn);

                storeAddress = storeAddress.Where(x => !(inBox.MinPoint.Latitude <= x.Lat && x.Lng <= inBox.MaxPoint.Latitude && inBox.MinPoint.Longitude <= x.Lng && x.Lng <= inBox.MinPoint.Latitude)).ToList();
            }
            ids = storeAddress.Select(y => y.Id);
            storeAddress = null;
            var stores = await storeRepository.FindAsync(x => ids.Contains(x.Id));
            ids = null;

            var rs = new List<CardStoreDto>();
            foreach (var store in stores)
            {
                var address = await addressRepository.FindByIdAsync(store.AddressId);
                rs.Add(new CardStoreDto()
                {
                    StoreName = store.Name,
                    Star = store.SumStar / store.NumReiview,
                    StoreId = store.Id,
                    Address = address.Addrress,
                    Distance = new Coordinates(48.672309, 15.695585)
                                .DistanceTo(
                                    new Coordinates(48.237867, 16.389477),
                                    UnitOfLength.Kilometers
                                ),
                    NumOfReView = store.NumReiview
                });
            }

            return rs.OrderBy(x => x.Distance).ToList();
        }

        private async Task<List<CardStoreDto>> GetStoreNearByAsync(GetStoreNearByDto getStoreNearByDto, IList<Address> addresses)
        {
            var box = MapCoordinates.GetBoundingBox(new MapPoint()
            {
                Latitude = getStoreNearByDto.Lat,
                Longitude = getStoreNearByDto.Lng
            }, getStoreNearByDto.RadiusOut);
            IList<Address> storeAddress;
            IEnumerable<string> ids;
            storeAddress = addresses.Where(x => box.MinPoint.Latitude <= x.Lat && x.Lng <= box.MaxPoint.Latitude && box.MinPoint.Longitude <= x.Lng && x.Lng <= box.MinPoint.Latitude).ToList();
            if (getStoreNearByDto.RadiusIn != 0)
            {
                var inBox = MapCoordinates.GetBoundingBox(new MapPoint()
                {
                    Latitude = getStoreNearByDto.Lat,
                    Longitude = getStoreNearByDto.Lng
                }, getStoreNearByDto.RadiusIn);

                storeAddress = storeAddress.Where(x => !(inBox.MinPoint.Latitude <= x.Lat && x.Lng <= inBox.MaxPoint.Latitude && inBox.MinPoint.Longitude <= x.Lng && x.Lng <= inBox.MinPoint.Latitude)).ToList();
            }
            ids = storeAddress.Select(y => y.Id);
            storeAddress = null;
            var stores = await storeRepository.FindAsync(x => ids.Contains(x.Id));
            ids = null;

            var rs = new List<CardStoreDto>();
            foreach (var store in stores)
            {
                var address = await addressRepository.FindByIdAsync(store.AddressId);
                rs.Add(new CardStoreDto()
                {
                    StoreName = store.Name,
                    Star = store.SumStar / store.NumReiview,
                    StoreId = store.Id,
                    Address = address.Addrress,
                    Distance = new Coordinates(48.672309, 15.695585)
                                .DistanceTo(
                                    new Coordinates(48.237867, 16.389477),
                                    UnitOfLength.Kilometers
                                ),
                    NumOfReView = store.NumReiview
                });
            }

            return rs.OrderBy(x => x.Distance).ToList();
        }

        public async Task<List<CardStoreDto>> FilterStoreNearByAsync(FilterStoreByCategoryId filterStoreByCategory)
        {
            var stores = await storeCateRepository.FindAsync(x => filterStoreByCategory.Equals(x.CategoryId));
            var storesId = stores.Select(x => x.StoreId);
            stores = null;
            var addresseId = await storeRepository.FindAsync(x => storesId.Contains(x.Id));
            storesId = null;
            return await GetStoreNearByAsync(new GetStoreNearByDto()
            {
                Lat = filterStoreByCategory.Lat,
                Lng = filterStoreByCategory.Lng,
                RadiusIn = filterStoreByCategory.RadiusIn,
                RadiusOut = filterStoreByCategory.RadiusOut
            }, await addressRepository.FindAsync(x => addresseId.Select(x => x.AddressId).Contains(x.Id)));
        }
    }
}
