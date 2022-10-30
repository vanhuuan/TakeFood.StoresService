using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using StoreService.Model.Entities.Category;
using StoreService.Model.Entities.Image;
using StoreService.Model.Repository;
using StoreService.Service;
using StoreService.Service.Implement;
using TakeFood.StoreService.ViewModel.Dtos.Image;

namespace TakeFood.StoreService.Service.Implement
{
    public class ImageService : IImageService
    {
        private readonly IMongoRepository<Image> ImageRepository;
        private readonly string BucketName = "pbl6-take-food";
        private readonly string AccessKey = "AKIATTWTHPVOAPEFLFND";
        private readonly string SecretKey = "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";
        private readonly string UrlBase = "https://pbl6-take-food.s3.ap-southeast-1.amazonaws.com/";
        private readonly ICategoryService categoryService;

        public ImageService(IMongoRepository<Image> mongoRepository, ICategoryService _categoryService)
        {
            ImageRepository = mongoRepository;
            categoryService = _categoryService;
        }

        public async Task CreateImage(string storeID, string categoryID, string Type, IFormFile image)
        {
            string category = (await categoryService.GetCategoryById(categoryID)).Name;
            Image _image = new Image()
            {
                StoreId = storeID,
                CategoryId = categoryID,
                Url = $"{UrlBase}{storeID}/{Type}/{category}/{image.FileName}",
            };
            await PushS3Aws(storeID, category, Type, image);
            await ImageRepository.InsertAsync(_image);
        }

        public async Task PushS3Aws(string storeID, string category, string type, IFormFile formFile)
        {
            var credentials = new Amazon.Runtime.BasicAWSCredentials(AccessKey, SecretKey);
            var client = new AmazonS3Client(credentials, RegionEndpoint.USEast1);
            var buketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, BucketName);
            if (!buketExists)
            {
                var bucketRequest = new PutBucketRequest()
                {
                    BucketName = BucketName,
                    UseClientRegion = true
                };
                await client.PutBucketAsync(bucketRequest);
            }

            var objectRequest = new PutObjectRequest()
            {
                BucketName = BucketName,
                Key = $"{storeID}/{type}/{category}/{formFile.FileName}",
                InputStream = formFile.OpenReadStream(),
            };

            await client.PutObjectAsync(objectRequest);
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

        public Task UpdateImage(string id, ImageDto image)
        {
            throw new NotImplementedException();
        }
    }
}
