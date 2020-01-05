using System.Threading;
using System.Threading.Tasks;
using Application.UserProfiles.Commands.CreateUserProfile;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserProfiles.Commands
{
    public class CreateUserCommandtests : CommandTestBase
    {
        private readonly CreateUserProfileCommandHandler _sut;
        private readonly Mock<IMediator> _mediatorMock;

        public CreateUserCommandtests()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _sut = new CreateUserProfileCommandHandler(Context, _mediatorMock.Object, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateUser()
        {
            // Arrange
            var command = new CreateUserProfileCommand { UserId = "test-1111", Email = "test@email.com", UserName = "Test" };

            // Act
            var user = await _sut.Handle(command, CancellationToken.None);
            var result = await Context.UserProfiles.FindAsync(user.Id);

            // // Assert
            result.UserName.ShouldBe(command.UserName);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseMovieCreatedNotification()
        {
            // Arrange
            var command = new CreateUserProfileCommand { UserId = "test-1111", Email = "test@email.com", UserName = "Test" };

            // Act
            var result = _sut.Handle(command, CancellationToken.None);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.Is<UserProfileCreated>(uc => uc.Id != 0), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}