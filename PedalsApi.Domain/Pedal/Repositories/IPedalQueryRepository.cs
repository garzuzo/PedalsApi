namespace PedalsApi.Domain.Pedal.Repositories;

public interface IPedalQueryRepository
{
    Task<Pedal> GetPedalById(Guid id);
    IEnumerable<Pedal> GetPedals();
    Task<bool> PedalExistsById(Guid id);
}
