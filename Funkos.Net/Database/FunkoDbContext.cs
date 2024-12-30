using Microsoft.EntityFrameworkCore;

namespace Funkos.Net.Database;

public class FunkoDbContext(DbContextOptions<FunkoDbContext> options) : DbContext(options)
{
    public DbSet<FunkoEntity> Funkos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FunkoEntity>(entity =>
        {
            entity.Property(e => e.CreatedAt).IsRequired()
                .ValueGeneratedOnAdd(); 
            entity.Property(e => e.UpdatedAt).IsRequired()
                .ValueGeneratedOnUpdate();
        });
    }
}