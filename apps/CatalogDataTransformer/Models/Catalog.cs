using System.Text.Json.Serialization;

namespace CatalogDataTransformer.Models;

public class Catalog
{
    [JsonPropertyName("catalogId")]
    public int CatalogId { get; set; }
    [JsonPropertyName("releaseId")]
    public int ReleaseId { get; set; }
    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }
    [JsonPropertyName("vendorCode")]
    public string VendorCode { get; set; } = string.Empty;
    [JsonPropertyName("catalogCode")]
    public string CatalogCode { get; set; } = string.Empty;
    [JsonPropertyName("catalogName")]
    public string CatalogName { get; set; } = string.Empty;
    [JsonPropertyName("catalogRelease")]
    public string CatalogRelease { get; set; } = string.Empty;
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;
    [JsonPropertyName("orderType")]
    public string OrderType { get; set; } = string.Empty;
    [JsonPropertyName("effectiveDate")]
    public DateTime? EffectiveDate { get; set; }
    [JsonPropertyName("toc")]
    public ICollection<CatalogTOC> TOC { get; set; } = new List<CatalogTOC>();
}
