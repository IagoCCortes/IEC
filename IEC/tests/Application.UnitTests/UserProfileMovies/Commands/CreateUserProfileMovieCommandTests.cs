using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UserProfileMovies.Commands.CreateUserProfileMovie;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.UserProfileMovies.Commands
{
    public class CreateUserProfileMovieCommandTests : CommandTestBase
    {
        private readonly IMapper _mapper;
        private readonly CreateUserProfileMovieCommandHandler _sut;

        public CreateUserProfileMovieCommandTests()
            : base()
        {       
            _mapper = Mapper;  
            _sut = new CreateUserProfileMovieCommandHandler(Context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateUserMovie()
        {
            // Arrange
            var command = new CreateUserProfileMovieCommand { MovieId = 1, UserProfileId = 1, UserProfileMovieStatusId = 1};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var userMovie = await Context.UserProfileMovies.FirstOrDefaultAsync(um => um.MovieId == 1 && um.UserProfileId == 1);

            // Assert
            Assert.NotNull(userMovie);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateUserProfileMovieCommand { MovieId = 99, UserProfileId = 1, UserProfileMovieStatusId = 1};

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}