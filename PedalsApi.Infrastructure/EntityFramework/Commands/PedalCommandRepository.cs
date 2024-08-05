using PedalsApi.Domain.Pedal;
using PedalsApi.Domain.Pedal.Repositories;
using PedalsApi.Infrastructure.EntityFramework.DbContexts;

namespace PedalsApi.Infrastructure.EntityFramework.Commands;

public class PedalCommandRepository : IPedalCommandRepository
{
    private readonly PedalsContext _context;

    public PedalCommandRepository(PedalsContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Pedal pedal)
    {
        var currentPedal = _context.Pedals.Find(pedal.Id);
        if (currentPedal is null)
        {
            await _context.Pedals.AddAsync(pedal);
            await _context.SaveChangesAsync();
        }
    }
}
