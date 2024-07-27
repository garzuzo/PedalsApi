namespace PedalApi.Application.Interfaces;
using PedalsApi.Domain.Pedal;

public interface IGetPedalUseCase
{
    Task<Pedal> GetAsync(Guid id);
    IEnumerable<Pedal> GetAll();
}
