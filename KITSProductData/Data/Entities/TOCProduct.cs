using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("TOC_Product")]
public class TOCProduct
{
    public int ProductId { get; set; }
    public int NodeId { get; set; } 
    public byte SeqNo { get; set; }
    public CatalogTOC CatalogTOC { get; set; } = null!;
    public Product Product { get; set; } = null!;
}