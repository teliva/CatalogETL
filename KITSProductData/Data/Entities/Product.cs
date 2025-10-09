using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("Product")]
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public int CatalogId { get; set; }
    [Required]
    public int DescriptionId { get; set; }
    [Required]
    public int PriceGroupId { get; set; }
    public double? Weight { get; set; }
    public int? NoteId { get; set; }
    [Required]
    public bool wf3dOK { get; set; } = false;
    [Required]
    public bool lineartOK { get; set; } = false;
    [Required]
    public string StyleNumber { get; set; } = null!;
    [StringLength(10)]
    public string? unspsc { get; set; }
    [StringLength(8)]
    public string? libCode { get; set; }
    [StringLength(255)]
    public string? Symbol { get; set; }
    [Required]
    public int CustomTagId1 { get; set; } = 0;
    [Required]
    public int CustomTagId2 { get; set; } = 0;
    [Required]
    public short PckgCount { get; set; } = 1;
    [StringLength(256)]
    public string? BoundingBox { get; set; }
    [Required]
    public bool PCEProduct { get; set; } = false;
    [StringLength(255)]
    public string? guid { get; set; }
    [ForeignKey("CatalogId")]
    public virtual Catalog? Catalog { get; set; }
    public ICollection<TOCProduct> TOCProducts { get; set; } = new List<TOCProduct>();
}