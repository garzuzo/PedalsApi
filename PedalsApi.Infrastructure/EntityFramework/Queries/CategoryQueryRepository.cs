
using Microsoft.EntityFrameworkCore;
using PedalsApi.Domain.Category;
using PedalsApi.Domain.Category.Repositories;
using PedalsApi.Infrastructure.EntityFramework.DbContexts;

namespace PedalsApi.Infrastructure.EntityFramework.Queries;

public class CategoryQueryRepository : ICategoryQueryRepository
{
    private readonly PedalsContext _context;
    public CategoryQueryRepository(PedalsContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> GetCategories()
    {
        var categories = _context.Categories;
        return categories;
    }
    public async Task<Category> GetCategoryById(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);

        return category;
    }
}
