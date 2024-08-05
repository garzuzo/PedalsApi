using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedalsApi.Domain.Category;

namespace PedalsApi.Infrastructure.EntityFramework.DbContexts.ModelBuilders;

public static class CategoryModelBuilder
{
    public static void Configure(this EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name);
    }
}
