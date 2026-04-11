using System.Text.Json.Serialization;

namespace CatalogDataTransformer.Models;

public class Product
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }
    [JsonPropertyName("modelNumber")]
    public string ModelNumber { get; set; } = null!;
    [JsonPropertyName("pceProduct")]
    public bool PCEProduct { get; set; } = false;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("enhancedDescription")]
    public string EnhancedDescription { get; set; } = string.Empty;
}