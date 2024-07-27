using Microsoft.EntityFrameworkCore;
using PedalsApi.Domain.Pedal;
using PedalsApi.Domain.Pedal.Repositories;
using PedalsApi.Infrastructure.EntityFramework.DbContexts;

namespace PedalsApi.Infrastructure.EntityFramework.Queries;

public class PedalQueryRepository : IPedalQueryRepository
{
    private readonly PedalsContext _context;
    public PedalQueryRepository(PedalsContext context)
    {
        _context = context;
    }
    public async Task<Pedal?> GetPedalById(Guid id)
    {
        return await _context.Pedals.Include(x => x.Medias).FirstOrDefaultAsync(x => x.Id == id);
    }

    public IEnumerable<Pedal> GetPedals()
    {
        return _context.Pedals.Include(x => x.Medias);
    }

    public async Task<bool> PedalExistsById(Guid id)
    {
        return await _context.Pedals.AnyAsync(x => x.Id == id);
    }
}
