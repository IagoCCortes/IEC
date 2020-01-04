using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UnitTests.Common;
using Application.UserMovies.Commands.UpdateUserMovie;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserMovies.Commands
{
    public class UpdateUserMovieCommandTests : CommandTestBase
    {
        private readonly IMapper _mapper;
        private readonly UpdateUserMovieCommandHandler _sut;

        public UpdateUserMovieCommandTests()
            : base()
        {       
            _mapper = Mapper;  
            _sut = new UpdateUserMovieCommandHandler(Context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateUserMovie()
        {
            // Arrange
            var command = new UpdateUserMovieCommand { MovieId = 2, UserId = 2, UserMovieStatusId = 3};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var userMovie = await Context.UserMovies.FirstOrDefaultAsync(um => um.MovieId == 2 && um.UserId == 2);

            // Assert
            userMovie.UserMovieStatusId.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateUserMovieCommand { MovieId = 99, UserId = 1, UserMovieStatusId = 1};

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}