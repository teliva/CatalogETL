using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("TOC_Product")]
public class TOCProduct
{
    public int ProductId { get; set; }
    public int NodeId { get; set; } 
    public short SeqNo { get; set; }
    public Product Product { get; set; } = null!;
}