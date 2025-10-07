using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class KITSProductRepository : IKITSProductRepository
{
    private readonly KITSProductContext _context;

    public KITSProductRepository(KITSProductContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Catalog>> GetAllAsync()
    {
        return await _context.Catalog.ToListAsync();
    }

    public async Task<Catalog?> GetByIdAsync(int catalogId)
    {
        return await _context.Catalog.FindAsync(catalogId);
    }
}
