using Bogus;
using FluentAssertions;
using JPProject.Admin.Domain.CommandHandlers;
using JPProject.Admin.Domain.Commands.PersistedGrant;
using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Domain.Tests.CommandHandlers.PersistedGrantsTests.Fakers;
using JPProject.Domain.Core.Bus;
using JPProject.Domain.Core.Notifications;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JPProject.Admin.Domain.Tests.CommandHandlers.PersistedGrantsTests
{
    public class PersistedGrantsCommandTests
    {
        private Faker _faker;
        private readonly CancellationTokenSource _tokenSource;
        private readonly Mock<IAdminUnitOfWork> _uow;
        private readonly Mock<DomainNotificationHandler> _notifications;
        private readonly Mock<IMediatorHandler> _mediator;
        private readonly PersistedGrantCommandHandler _commandHandler;
        private readonly Mock<IPersistedGrantRepository> _persistedGrantRepository;

        public PersistedGrantsCommandTests()
        {
            _faker = new Faker();
            _tokenSource = new CancellationTokenSource();
            _uow = new Mock<IAdminUnitOfWork>();
            _mediator = new Mock<IMediatorHandler>();
            _notifications = new Mock<DomainNotificationHandler>();
            _persistedGrantRepository = new Mock<IPersistedGrantRepository>();
            _commandHandler = new PersistedGrantCommandHandler(_uow.Object, _mediator.Object, _notifications.Object, _persistedGrantRepository.Object);
        }

        [Fact]
        public async Task ShouldRemovePersistedGrant()
        {
            var command = PersistedGrantCommandFaker.GenerateRemoveCommand().Generate();


            _persistedGrantRepository.Setup(s => s.Remove(command.Key));

            _uow.Setup(v => v.Commit()).ReturnsAsync(true);

            var result = await _commandHandler.Handle(command, _tokenSource.Token);

            _uow.Verify(v => v.Commit(), Times.Once);

            result.Should().BeTrue();
        }


        [Fact]
        public async Task ShouldNotRemovePersistedGrantWhenKeyIsNull()
        {
            var command = new RemovePersistedGrantCommand(null);

            var result = await _commandHandler.Handle(command, _tokenSource.Token);

            result.Should().BeFalse();
        }


        [Fact]
        public async Task ShouldNotRemovePersistedGrantWhenKeyDoesntExist()
        {
            var command = PersistedGrantCommandFaker.GenerateRemoveCommand().Generate();
            _persistedGrantRepository.Setup(s => s.Remove(command.Key));

            _uow.Setup(v => v.Commit()).ReturnsAsync(false);

            var result = await _commandHandler.Handle(command, _tokenSource.Token);

            _uow.Verify(v => v.Commit(), Times.Once);

            result.Should().BeFalse();
        }

    }
}
