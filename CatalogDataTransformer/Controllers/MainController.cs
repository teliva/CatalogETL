using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Repository;

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

    public async Task Fetcher(int catalogId)
    {
        var cat = await _kpr.GetByIdAsync(catalogId);
        Console.WriteLine(cat?.CatalogName);

    }
}