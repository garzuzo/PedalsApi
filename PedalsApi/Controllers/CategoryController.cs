
using Microsoft.AspNetCore.Mvc;
using PedalApi.Application.Interfaces;
using PedalsApi.Domain.Category;

namespace PedalsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private IGetCategoryUseCase _getCategoryUseCase;
    private ICreateCategoryUseCase _createCategoryUseCase;
    public CategoryController(IGetCategoryUseCase getCategoryUseCase, ICreateCategoryUseCase createCategoryUseCase)
    {
        _getCategoryUseCase = getCategoryUseCase;
        _createCategoryUseCase = createCategoryUseCase;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(_getCategoryUseCase.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _getCategoryUseCase.GetAsync(id);
        if (category is not null)
        {
            return Ok(category);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category)
    {
        await _createCategoryUseCase.CreateAsync(category);
        return Ok();
    }
}
