
using Data.Entities;
public interface IKITSProductRepository
{
    Task<IEnumerable<Catalog>> GetAllAsync();
    Task<Catalog?> GetByIdAsync(int catalogId);
}