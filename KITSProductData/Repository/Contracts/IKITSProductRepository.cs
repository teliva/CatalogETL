
using Data.Entities;
public interface IKITSProductRepository
{
    Task<IEnumerable<Catalog>> GetAllAsync();
    Task<Catalog?> GetByIdAsync(int catalogId);
    Task<IList<CatalogTOC>> GetCatalogTOCList(int catalogId);
    Task<IList<Product>> GetProductsByCatalog(int catalogId);
}