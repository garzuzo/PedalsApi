
using Microsoft.AspNetCore.Mvc;
using PedalApi.Application.Interfaces;
using PedalsApi.Domain.Pedal;

namespace PedalsApi.Controller;

[ApiController]
[Route("[controller]")]
public class PedalController : ControllerBase
{
    private IGetPedalUseCase _getPedalUseCase;
    private ICreatePedalUseCase _createPedalUseCase;

    public PedalController(IGetPedalUseCase getPedalUseCase, ICreatePedalUseCase createPedalUseCase)
    {
        _getPedalUseCase = getPedalUseCase;
        _createPedalUseCase = createPedalUseCase;
    }

    [HttpGet]
    public IActionResult GetPedals()
    {
        return Ok(_getPedalUseCase.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPedalById(Guid id)
    {
        var pedal = await _getPedalUseCase.GetAsync(id);
        if (pedal is not null)
        {
            return Ok(pedal);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pedal pedal)
    {
        await _createPedalUseCase.CreateAsync(pedal);
        return Ok();
    }
}
