using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("Catalog_TOC")]
public class CatalogTOC
{
    [Key]
    public int NodeId { get; set; }
    public int CatalogId { get; set; }
    public int ParentId { get; set; }

    [MaxLength(128)]
    public string NodeName { get; set; } = string.Empty;
    public byte Depth { get; set; }
    [Column("left_")]
    public int Left { get; set; }
    [Column("right_")]
    public int Right { get; set; }
    [Column("guid")]
    public string? Guid { get; set; }
    [MaxLength(255)]
    public string? GroupLabel { get; set; }
    public required Catalog Catalog { get; set; }
}