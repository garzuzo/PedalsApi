using PedalApi.Application.Interfaces;
using PedalsApi.Domain.Pedal;
using PedalsApi.Domain.Pedal.Repositories;

namespace PedalsApi.Application.UseCases;

public class CreatePedalUseCase(IPedalCommandRepository pedalCommandRepository, IPedalQueryRepository pedalQueryRepository) : ICreatePedalUseCase
{

    public async Task CreateAsync(Pedal pedal)
    {
        var pedalExists = await pedalQueryRepository.PedalExistsById(pedal.Id);
        if (pedalExists)
        {
            throw new Exception("Pedal already exists");
        }
        else
        {
            await pedalCommandRepository.CreateAsync(pedal);
        }
    }
}
