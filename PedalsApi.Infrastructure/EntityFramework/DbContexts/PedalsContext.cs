using Microsoft.EntityFrameworkCore;
using PedalsApi.Domain.Category;
using PedalsApi.Domain.Pedal;
using PedalsApi.Infrastructure.EntityFramework.DbContexts.ModelBuilders;

namespace PedalsApi.Infrastructure.EntityFramework.DbContexts;
public class PedalsContext : DbContext
{
    public DbSet<Pedal> Pedals { get; set; }
    public DbSet<Category> Categories { get; set; }
    public PedalsContext(DbContextOptions<PedalsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedal>().Configure();
        modelBuilder.Entity<Category>().Configure();
    }
}
