namespace PedalApi.Application.Interfaces;
using PedalsApi.Domain.Pedal;

public interface ICreatePedalUseCase
{
    Task CreateAsync(Pedal pedal);
}
