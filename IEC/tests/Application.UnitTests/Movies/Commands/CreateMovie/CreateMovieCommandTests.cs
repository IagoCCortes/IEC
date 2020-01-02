using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Movies.Commands.CreateMovie;
using Application.UnitTests.Common;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandTests : CommandTestBase
    {
        private readonly CreateMovieCommandHandler _sut;
        private readonly Mock<IMediator> _mediatorMock;

        public CreateMovieCommandTests()
            : base()
        {
            _mediatorMock = new Mock<IMediator>();
            _sut = new CreateMovieCommandHandler(Context, _mediatorMock.Object, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateMovie()
        {
            // Arrange
            var command = new CreateMovieCommand { Title = "test", ReleaseDate = DateTime.Now };

            // Act
            var movie = await _sut.Handle(command, CancellationToken.None);
            var result = await Context.Movies.FindAsync(movie.Id);

            // // Assert
            result.Title.ShouldBe(command.Title);
        }

        [Fact]
        public void Handle_GivenValidRequest_ShouldRaiseCustomerCreatedNotification()
        {
            // Arrange
            var command = new CreateMovieCommand { Title = "test", ReleaseDate = DateTime.Now };

            // Act
            var result = _sut.Handle(command, CancellationToken.None);

            // Assert
            _mediatorMock.Verify(m => m.Publish(It.Is<MovieCreated>(mc => mc.Id != 0), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}