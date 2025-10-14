using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Repository;
using CatalogDataTransformer.Models;
using CatalogDataTransformer.Maps;

public class MainController
{
    private KITSProductRepository _kpr;
    private readonly KITSProductContext _context;

    public MainController(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("No connection string", nameof(connectionString));
        }

        var options = new DbContextOptionsBuilder<KITSProductContext>()
            .UseSqlServer(connectionString)
            .Options;

        _context = new KITSProductContext(options);
        _kpr = new KITSProductRepository(_context);
    }

    public async Task GetCatalogById(int catalogId)
    {
        var cat = await _kpr.GetByIdAsync(catalogId);
    }

    public async Task<CatalogTOC?> GetCatalogNodes(int catalogId)
    {
        var cat = await _kpr.GetCatalogTOCList(catalogId);
        return CatalogMapper.ToDomain(cat);
    }

    public async Task<IList<Product>> GetCatalogProducts(int catalogId)
    {
        var products = await _kpr.GetProductsByCatalog(catalogId);
        return CatalogMapper.ToDomain(products);
    }
}