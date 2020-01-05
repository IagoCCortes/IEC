using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.UserProfileMovies.Commands.UpdateUserProfileMovie;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace Application.UnitTests.UserProfileMovies.Commands
{
    public class UpdateUserMovieCommandTests : CommandTestBase
    {
        private readonly IMapper _mapper;
        private readonly UpdateUserProfileMovieCommandHandler _sut;

        public UpdateUserMovieCommandTests()
            : base()
        {       
            _mapper = Mapper;  
            _sut = new UpdateUserProfileMovieCommandHandler(Context, _mapper);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateUserMovie()
        {
            // Arrange
            var command = new UpdateUserProfileMovieCommand { MovieId = 2, UserProfileId = 2, UserMovieStatusId = 3};

            // Act
            await _sut.Handle(command, CancellationToken.None);
            var userMovie = await Context.UserProfileMovies.FirstOrDefaultAsync(um => um.MovieId == 2 && um.UserProfileId == 2);

            // Assert
            userMovie.UserProfileMovieStatusId.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateUserProfileMovieCommand { MovieId = 99, UserProfileId = 1, UserMovieStatusId = 1};

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));            
        }
    }
}