using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("TOC_Product")]
public class TOCProduct
{
    [Key]
    public int ProductId { get; set; }

    public int NodeId { get; set; }

    public byte SeqNo { get; set; }
}