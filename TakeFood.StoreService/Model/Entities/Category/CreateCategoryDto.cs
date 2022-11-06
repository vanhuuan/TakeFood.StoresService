using System.Text.Json.Serialization;

namespace TakeFood.StoreService.Model.Entities.Category
{
    public class CreateCategoryDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
