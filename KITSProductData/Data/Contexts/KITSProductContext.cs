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
        // Catalog
        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(x => x.CatalogId);
            entity.ToTable("Catalog");

            entity.HasMany(c => c.TOC)
                  .WithOne()
                  .HasForeignKey(t => t.CatalogId);
        });

        // CatalogTOC
        modelBuilder.Entity<CatalogTOC>(entity =>
        {
            entity.ToTable("Catalog_TOC");
            entity.HasKey(x => x.NodeId);
        });

        // TOCProduct
        modelBuilder.Entity<TOCProduct>(entity =>
        {
            entity.ToTable("TOC_Product");

            entity.HasKey(x => new { x.ProductId, x.NodeId });

            entity.HasOne(tp => tp.Product)
                  .WithMany()
                  .HasForeignKey(tp => tp.ProductId);
        });

        // Product
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasKey(x => x.ProductId);

            entity.HasOne(p => p.CatalogGenericDescription)
            .WithMany()
            .HasForeignKey(p => p.DescriptionId);
        });
    }
}