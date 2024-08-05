namespace PedalApi.Application.Interfaces;
using PedalsApi.Domain.Category;

public interface ICreateCategoryUseCase
{
    Task CreateAsync(Category category);
}
