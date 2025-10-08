namespace CatalogDataTransformer.Models;

public class CatalogTOC
{
    public int NodeId { get; set; }
    public int CatalogId { get; set; }
    public int ParentId { get; set; }
    public string NodeName { get; set; } = string.Empty;
    public byte Depth { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }
    public Guid Guid { get; set; }
    public string GroupLabel { get; set; } = string.Empty;
    public ICollection<TOCProduct> TOCProducts { get; set; } = new List<TOCProduct>();
    public ICollection<CatalogTOC> TOCNodes { get;set; } = new List<CatalogTOC>();
}