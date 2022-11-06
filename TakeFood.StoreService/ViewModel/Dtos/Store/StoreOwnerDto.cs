using System.Text.Json.Serialization;

namespace TakeFood.StoreService.ViewModel.Dtos.Store
{
    public class StoreOwnerDto
    {
        [JsonPropertyName("storeId")]
        public string? StoreId { get; set; }
        [JsonPropertyName("NameStore")]
        public string? StoreName { get; set; }
        [JsonPropertyName("Phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("NameOwner")]
        public string? NameOwner { get; set; }
        [JsonPropertyName("STK")]
        public string? STK { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }
        [JsonPropertyName("Email")]
        public string? Email { get; set; }
        [JsonPropertyName("CMND")]
        public string? CMND { get; set; }
        [JsonPropertyName("NameBank")]
        public string? NameBank { get; set; }
        [JsonPropertyName("QuantityOfFood")]
        public int QuantityFood { get; set; }
        [JsonPropertyName("State")]
        public string? State { get; set; }
    }
}
