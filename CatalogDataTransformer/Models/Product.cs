namespace CatalogDataTransformer.Models;

public class Product
{    public int ProductId { get; set; }
    public int CatalogId { get; set; }
    public int DescriptionId { get; set; }
    public int PriceGroupId { get; set; }
    public double? Weight { get; set; }
    public int? NoteId { get; set; }
    public bool wf3dOK { get; set; } = false;
    public bool lineartOK { get; set; } = false;
    public string StyleNumber { get; set; } = null!;
    public string? unspsc { get; set; }
    public string? libCode { get; set; }
    public string? Symbol { get; set; }
    public int CustomTagId1 { get; set; } = 0;
    public int CustomTagId2 { get; set; } = 0;
    public short PckgCount { get; set; } = 1;
    public string? BoundingBox { get; set; }
    public bool PCEProduct { get; set; } = false;
    public string? guid { get; set; }
}