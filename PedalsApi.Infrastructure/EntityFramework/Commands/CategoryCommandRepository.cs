using PedalsApi.Domain.Category;
using PedalsApi.Domain.Category.Repositories;
using PedalsApi.Infrastructure.EntityFramework.DbContexts;

namespace PedalsApi.Infrastructure.EntityFramework.Commands;

public class CategoryCommandRepository : ICategoryCommandRepository
{
    private readonly PedalsContext _context;
    public CategoryCommandRepository(PedalsContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Category category)
    {
        var currentCategory = _context.Categories.Find(category.Id);
        if (currentCategory is null)
        {
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();
        }
    }
}
