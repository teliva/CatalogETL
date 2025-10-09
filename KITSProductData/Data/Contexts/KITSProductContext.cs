using Microsoft.EntityFrameworkCore;

using Data.Entities;
using System.Security.Cryptography.X509Certificates;

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
                  .WithOne(t => t.Catalog)
                  .HasForeignKey(t => t.CatalogId);
        });

        // CatalogTOC
        modelBuilder.Entity<CatalogTOC>(entity =>
        {
            entity.ToTable("Catalog_TOC");
            entity.HasKey(x => x.NodeId);

            entity.HasOne(x => x.Catalog)
                  .WithMany(c => c.TOC)
                  .HasForeignKey(x => x.CatalogId);

            // entity.HasMany(x => x.TOCProducts)
            //       .WithOne(tp => tp.CatalogTOC)
            //       .HasForeignKey(tp => tp.NodeId);
        });

        // TOCProduct
        modelBuilder.Entity<TOCProduct>(entity =>
        {
            entity.ToTable("TOC_Product");

            entity.HasKey(x => new { x.ProductId, x.NodeId });

            // entity.HasOne(tp => tp.CatalogTOC)
            //       .WithMany(toc => toc.TOCProducts)
            //       .HasForeignKey(tp => tp.NodeId);

            entity.HasOne(tp => tp.Product)
                  .WithMany(p => p.TOCProducts)
                  .HasForeignKey(tp => tp.ProductId);
        });
    }
}