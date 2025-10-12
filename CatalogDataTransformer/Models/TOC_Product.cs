using System.Text.Json.Serialization;

namespace CatalogDataTransformer.Models;

public class TOCProduct : Product
{
    [JsonPropertyName("nodeId")]
    public int NodeId { get; set; }
    [JsonPropertyName("seqNo")]
    public short SeqNo { get; set; }
}