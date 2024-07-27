namespace PedalsApi.Domain.Category.Repositories;

public interface ICategoryCommandRepository
{
    Task CreateAsync(Category category);
}
