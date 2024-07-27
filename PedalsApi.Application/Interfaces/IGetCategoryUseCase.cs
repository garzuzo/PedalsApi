namespace PedalApi.Application.Interfaces;
using PedalsApi.Domain.Category;

public interface IGetCategoryUseCase
{
    Task<Category> GetAsync(Guid id);
    IEnumerable<Category> GetAllAsync();
}
