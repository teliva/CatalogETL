using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("Catalog")]
public class Catalog
{
    [Key]
    public int CatalogId { get; set; }

    public int ReleaseId { get; set; }

    public bool IsActive { get; set; }

    [MaxLength(8)]
    public string VendorCode { get; set; } = string.Empty;

    [MaxLength(8)]
    public string CatalogCode { get; set; } = string.Empty;

    [MaxLength(64)]
    public string CatalogName { get; set; } = string.Empty;

    [MaxLength(64)]
    public string CatalogRelease { get; set; } = string.Empty;

    [MaxLength(8)]
    public string Currency { get; set; } = string.Empty;

    [MaxLength(8)]
    public string Language { get; set; } = string.Empty;

    [MaxLength(8)]
    public string OrderType { get; set; } = string.Empty;

    public DateTime? EffectiveDate { get; set; }
}
