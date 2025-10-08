using Microsoft.EntityFrameworkCore;

using Data.Entities;

namespace Data.Contexts;

public class KITSProductContext : DbContext
{
    public virtual DbSet<Catalog> Catalog { get; set; }
    public virtual DbSet<CatalogTOC> CatalogTOC { get; set; }
    public virtual DbSet<TOCProduct> TOCProduct { get; set; }

    public KITSProductContext(DbContextOptions<KITSProductContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(@"Server=[server];Database=[database];User ID=[user];Password='[password]';MultipleActiveResultSets=true;Persist Security Info=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateModel(modelBuilder);
    }

    private void CreateModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(x => x.CatalogId);
            entity.ToTable("Catalog");
        });

        modelBuilder.Entity<CatalogTOC>(entity =>
        {
            entity.HasKey(x => x.NodeId);
            entity.HasOne(x => x.Catalog)
            .WithMany(c => c.TOC)
            .HasForeignKey(x => x.CatalogId);
            entity.ToTable("Catalog_TOC");
        });
    }
}