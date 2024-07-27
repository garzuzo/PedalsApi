using Moq;
using PedalsApi.Application;
using PedalsApi.Application.UseCases;
using PedalsApi.Domain;
using PedalsApi.Domain.Pedal;
using PedalsApi.Domain.Pedal.Repositories;

namespace PedalsApi.Application.UnitTests;

public class CreatePedalUseCaseTest
{
    [Fact]
    public async void CreateAsync_ValidPedal_ReturnsPedal()
    {

        // Arrange
        var pedalCommandRepository = new Mock<IPedalCommandRepository>();
        var pedalQueryRepository = new Mock<IPedalQueryRepository>();
        var pedal = new Pedal();
        var createPedalUseCase = new CreatePedalUseCase(pedalCommandRepository.Object, pedalQueryRepository.Object);
        // Act
        await createPedalUseCase.CreateAsync(pedal);
        // Assert
        pedalCommandRepository.Verify(x => x.CreateAsync(It.IsAny<Pedal>()), Times.Once);
    }
    [Fact]
    public async void CreateAsync_ExistentPedal_ThrowsException()
    {
        // Arrange
        var pedalId = new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479");
        var pedalCommandRepository = new Mock<IPedalCommandRepository>();
        var pedalQueryRepository = new Mock<IPedalQueryRepository>();
        pedalQueryRepository.Setup(x => x.PedalExistsById(It.Is<Guid>(x => x.Equals(pedalId)))).ReturnsAsync(true);
        var pedal = new Pedal { Id = pedalId };
        var createPedalUseCase = new CreatePedalUseCase(pedalCommandRepository.Object, pedalQueryRepository.Object);
        // Act - Assert
        var exception = await Assert.ThrowsAsync<Exception>(async () => await createPedalUseCase.CreateAsync(pedal));
    }
}
