using PedalApi.Application.Interfaces;
using PedalsApi.Domain.Category;
using PedalsApi.Domain.Category.Repositories;

namespace PedalsApi.Application.UseCases;

public class GetCategoryUseCase(ICategoryQueryRepository categoryQueryRepository) : IGetCategoryUseCase
{
    public IEnumerable<Category> GetAllAsync()
    {
        var categories = categoryQueryRepository.GetCategories();
        return categories;
    }

    public async Task<Category> GetAsync(Guid id)
    {
        var category = await categoryQueryRepository.GetCategoryById(id);
        return category;
    }
}
