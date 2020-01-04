using System.Threading;
using System.Threading.Tasks;
using Application.UnitTests.Common;
using Application.Users.Commands.CreateUser;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Users.Commands
{
    public class CreateUserCommandtests : CommandTestBase
    {
        private readonly CreateUserCommandHandler _sut;
        private readonly Mock<IMediator> _mediatorMock;

        public CreateUserCommandtests()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _sut = new CreateUserCommandHandler(Context, _mediatorMock.Object, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateUser()
        {
            // Arrange
            var command = new CreateUserCommand { UserId = "test-1111", Email = "test@email.com", UserName = "Test" };

            // Act
            var user = await _sut.Handle(command, CancellationToken.None);
            var result = await Context.Users.FindAsync(user.Id);

            // // Assert
            result.UserName.ShouldBe(command.UserName);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseMovieCreatedNotification()
        {
            // Arrange
            var command = new CreateUserCommand { UserId = "test-1111", Email = "test@email.com", UserName = "Test" };

            // Act
            var result = _sut.Handle(command, CancellationToken.None);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.Is<UserCreated>(uc => uc.Id != 0), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}