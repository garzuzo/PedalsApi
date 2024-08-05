namespace PedalsApi.Domain.Category.Repositories;

public interface ICategoryQueryRepository
{
    Task<Category> GetCategoryById(Guid id);
    IEnumerable<Category> GetCategories();
}
