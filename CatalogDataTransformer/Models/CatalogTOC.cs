using System.Text.Json.Serialization;

namespace CatalogDataTransformer.Models;

public class CatalogTOC
{
    [JsonPropertyName("nodeId")]
    public int NodeId { get; set; }
    [JsonPropertyName("catalogId")]
    public int CatalogId { get; set; }
    [JsonPropertyName("parentId")]
    public int ParentId { get; set; }
    [JsonPropertyName("nodeName")]
    public string NodeName { get; set; } = string.Empty;
    [JsonPropertyName("depth")]
    public byte Depth { get; set; }
    [JsonPropertyName("left")]
    public int Left { get; set; }
    [JsonPropertyName("right")]
    public int Right { get; set; }
    [JsonPropertyName("guid")]
    public Guid Guid { get; set; }
    [JsonPropertyName("groupLabel")]
    public string GroupLabel { get; set; } = string.Empty;
    [JsonPropertyName("tocProducts")]
    public ICollection<TOCProduct> TOCProducts { get; set; } = new List<TOCProduct>();
    [JsonPropertyName("toc")]
    public ICollection<CatalogTOC> TOCNodes { get;set; } = new List<CatalogTOC>();
}