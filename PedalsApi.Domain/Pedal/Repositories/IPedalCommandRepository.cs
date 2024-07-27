namespace PedalsApi.Domain.Pedal.Repositories;

public interface IPedalCommandRepository
{
    Task CreateAsync(Pedal pedal);
}
