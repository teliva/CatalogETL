namespace CatalogDataTransformer.Models;

public class Product
{    public int ProductId { get; set; }
    public string ModelNumber { get; set; } = null!;
    public bool PCEProduct { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public string EnhancedDescription { get; set; } = string.Empty;
}