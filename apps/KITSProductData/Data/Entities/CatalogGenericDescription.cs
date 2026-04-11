using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("Catalog_GenericDescription", Schema = "dbo")]
public class CatalogGenericDescription
{
    [Key]
    [Column("descriptionId")]
    public int DescriptionId { get; set; }

    [Column("isProduct")]
    public bool IsProduct { get; set; }

    [Column("isGroup")]
    public bool IsGroup { get; set; }

    [Column("isOption")]
    public bool IsOption { get; set; }

    [Required]
    [Column("Description")]
    [StringLength(1200)]
    public string Description { get; set; } = string.Empty;

    [Column("EnhancedDescription")]
    [StringLength(1200)]
    public string? EnhancedDescription { get; set; }
}