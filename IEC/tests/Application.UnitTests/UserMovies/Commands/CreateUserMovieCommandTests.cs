using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Application.UserMovies.Commands.CreateUserMovie;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Application.UnitTests.UserMovies.Commands
{
    public class CreateUserMovieCommandTests : CommandTestBase
    {
        private readonly IMapper _mapper;
        private readonly CreateUserMovieCommandHandler _sut;

        public CreateUserMovieCommandTests()
            : base()
        {       
            _mapper = Mapper;  
            _sut = new CreateUserMovieCommandHandler(Context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldCreateUserMovie()
        {
            // Arrange
            var command = new CreateUserMovieCommand { MovieId = 1, UserId = 1, UserMovieStatusId = 1};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var userMovie = await Context.UserMovies.FirstOrDefaultAsync(um => um.MovieId == 1 && um.UserId == 1);

            // Assert
            Assert.NotNull(userMovie);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateUserMovieCommand { MovieId = 99, UserId = 1, UserMovieStatusId = 1};

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}