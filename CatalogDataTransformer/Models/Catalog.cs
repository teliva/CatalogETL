namespace CatalogDataTransformer.Models;

public class Catalog
{
    public int CatalogId { get; set; }
    public int ReleaseId { get; set; }
    public bool IsActive { get; set; }
    public string VendorCode { get; set; } = string.Empty;
    public string CatalogCode { get; set; } = string.Empty;
    public string CatalogName { get; set; } = string.Empty;
    public string CatalogRelease { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string OrderType { get; set; } = string.Empty;
    public DateTime? EffectiveDate { get; set; }
    public ICollection<CatalogTOC> TOC { get; set; } = new List<CatalogTOC>();
}
