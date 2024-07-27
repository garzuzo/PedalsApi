
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedalsApi.Domain.Pedal;

namespace PedalsApi.Infrastructure.EntityFramework.DbContexts.ModelBuilders;

public static class PedalModelBuilder
{
    public static void Configure(this EntityTypeBuilder<Pedal> builder)
    {
        builder.ToTable("Pedal");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name);
        builder.Property(p => p.Description);
        builder.HasMany(p => p.Medias).WithOne();
        builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
    }
}
