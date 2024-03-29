﻿using StoreService.Model.Entities.Image;
using StoreService.Model.Repository;
using TakeFood.StoreService.ViewModel.Dtos.Image;

namespace TakeFood.StoreService.Service.Implement
{
    public class ImageService : IImageService
    {
        private readonly IMongoRepository<Image> ImageRepository;

        public ImageService(IMongoRepository<Image> mongoRepository)
        {
            ImageRepository = mongoRepository;
        }

        public async Task CreateImage(string storeID, string categoryID, ImageDto image)
        {
            Image _image = new Image()
            {
                StoreId = storeID,
                CategoryId = categoryID,
                Url = image.Url,
            };
            await ImageRepository.InsertAsync(_image);
        }

        public Task DeleteImage(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageDto>> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public Task<ImageDto> GetImageById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStoreSlug(string storeId)
        {
            return (await ImageRepository.FindOneAsync(x => x.StoreId == storeId)).Url;
        }

        public async Task<IList<Image>> GetAllStoreSlug(string storeId)
        {
            return (await ImageRepository.FindAsync(x => x.StoreId == storeId));
        }

        public Task UpdateImage(string id, ImageDto image)
        {
            throw new NotImplementedException();
        }
    }
}
