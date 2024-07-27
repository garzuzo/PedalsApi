using PedalApi.Application.Interfaces;
using PedalsApi.Domain.Pedal;
using PedalsApi.Domain.Pedal.Repositories;

namespace PedalsApi.Application.UseCases;

public class GetPedalUseCase(IPedalQueryRepository pedalQueryRepository) : IGetPedalUseCase
{
    public IEnumerable<Pedal> GetAll()
    {
        var pedals = pedalQueryRepository.GetPedals();
        return pedals;
    }

    public async Task<Pedal?> GetAsync(Guid id)
    {
        return await pedalQueryRepository.GetPedalById(id);
    }
}
