using System.Text.Json.Serialization;

namespace StoreService.ViewModel.Dtos.Category
{
    public class CategoryDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
