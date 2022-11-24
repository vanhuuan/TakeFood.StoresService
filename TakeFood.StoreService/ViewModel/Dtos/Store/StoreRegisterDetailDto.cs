using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using TakeFood.StoreService.ViewModel.Dtos.Address;

namespace TakeFood.StoreService.ViewModel.Dtos.Store;

public class StoreRegisterDetailDto
{
    [JsonPropertyName("name")]
    public string StoreName { get; set; }

    [JsonPropertyName("phone")]
    public string StorePhone { get; set; }

    [JsonPropertyName("address")]
    public StoreAddressDto StoreAddress { get; set; }

    [JsonPropertyName("urlStoreImage")]
    public string urlStoreImage { get; set; }

    [JsonPropertyName("urlKitchenImage")]
    public string urlKitchenImage { get; set; }

    [JsonPropertyName("urlMenuImage")]
    public string urlMenuImage { get; set; }

    [JsonPropertyName("nameOwner")]
    public string nameOwner { get; set; }

    [JsonPropertyName("cmnd")]
    public string cmnd { get; set; }

    [JsonPropertyName("urlFontCmndImage")]
    public string urlFontCmndImage { get; set; }

    [JsonPropertyName("urlBackCmndImage")]
    public string urlBackCmndImage { get; set; }

    [JsonPropertyName("urlLicenseImage")]
    public string urlLicenseImage { get; set; }

    [JsonPropertyName("nameSTKOwner")]
    public string nameSTKOwner { get; set; }

    [JsonPropertyName("STK")]
    public string STK { get; set; }

    [JsonPropertyName("NameBank")]
    public string NameBank { get; set; }

    [JsonPropertyName("BankBranch")]
    [NotNull]
    public string BankBranch { get; set; }

    [JsonPropertyName("TaxID")]
    public string TaxID { get; set; }

    [JsonPropertyName("Categories")]
    public List<String> Categories { get; set; }
    [JsonPropertyName("State")]
    public string State { get; set; }
}
