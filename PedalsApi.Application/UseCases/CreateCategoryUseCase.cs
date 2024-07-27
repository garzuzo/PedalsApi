using System.Net.WebSockets;
using PedalApi.Application.Interfaces;
using PedalsApi.Domain.Category;
using PedalsApi.Domain.Category.Repositories;

namespace PedalsApi.Application.UseCases;

public class CreateCategoryUseCase(ICategoryCommandRepository categoryCommandRepository) : ICreateCategoryUseCase
{
    public Task CreateAsync(Category category)
    {
        return categoryCommandRepository.CreateAsync(category);
    }
}
