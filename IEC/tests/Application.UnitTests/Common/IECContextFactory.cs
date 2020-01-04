using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.Extensions.Options;
using Moq;
using Common;

namespace Application.UnitTests.Common
{
    public static class IECContextFactory
    {
        public static IECDbContext Create()
        {
            var options = new DbContextOptionsBuilder<IECDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var context = new IECDbContext(options, dateTimeMock.Object);

            context.Database.EnsureCreated();

            SeedSampleData(context);

            return context;
        }

        public static void Destroy(IECDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }

        public static void SeedSampleData(IECDbContext context)
        {

            context.Artists.AddRange(new[] {
                new Artist {Id = 1, ArtistName = "Tim Robbins", Birthplace = "West Covina, California, USA", Birthdate = DateTime.Parse("1958-10-16"), Deathdate = null, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_.jpg", Bio = "Ray Hamel", RealName = "Timothy Francis Robbins", Height = 196},
                new Artist {Id = 2, ArtistName = "Morgan Freeman", Birthplace = "Memphis, Tennessee, USA", Birthdate = DateTime.Parse("1937-06-01"), Deathdate = null, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTc0MDMyMzI2OF5BMl5BanBnXkFtZTcwMzM2OTk1MQ@@._V1_.jpg", Bio = "ance as The Messenger", RealName = null, Height = 188},
                new Artist {Id = 3, ArtistName = "Bob Gunton", Birthplace = "Santa Monica, California, USA", Birthdate = DateTime.Parse("1945-11-15"), Deathdate = null, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTc3MzY0MTQzM15BMl5BanBnXkFtZTcwMTM0ODYxNw@@._V1_.jpg", Bio = "Annie McGreevey.\n\n", RealName = "Robert Patrick Gunton Jr.", Height = 187},
            });

            context.Movies.AddRange( new[] {
                new Movie {Id = 1, Title = "Gone Girl", Runtime = 149, ReleaseDate = DateTime.Parse("2014-10-01"), Plot = "his wife's disappearance ha", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTk0MDQ3MzAzOV5BMl5BanBnXkFtZTgwNzU1NzE3MjE@._V1_.jpg"},
		        new Movie {Id = 2, Title = "Hacksaw Ridge", Runtime = 139, ReleaseDate = DateTime.Parse("2016-11-03"), Plot = "to kill people, and bec", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjQ1NjM3MTUxNV5BMl5BanBnXkFtZTgwMDc5MTY5OTE@._V1_.jpg"},
		        new Movie {Id = 3, Title = "Salinui chueok", Runtime = 131, ReleaseDate = DateTime.Parse("2003-05-02"), Plot = "an unknown culprit.", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMzhlNGJhYzUtZTNiMi00MjI0LWFjN2MtOTVlN2IxODVkZWVkXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"},
            });

            context.MovieArtists.AddRange( new[] {
                new MovieArtist {ArtistId = 1, MovieId = 2, RoleId = 1},
                new MovieArtist {ArtistId = 3, MovieId = 2, RoleId = 1}
            });

            context.MovieGenres.AddRange( new[] {
                new MovieGenre {Id = 1, Genre = "test1"},
                new MovieGenre {Id = 2, Genre = "test2"},
                new MovieGenre {Id = 3, Genre = "test3"}
            });

            context.MovieMovieGenres.AddRange( new[] {
                new MovieMovieGenre {MovieId = 2, MovieGenreId = 1},
                new MovieMovieGenre {MovieId = 2, MovieGenreId = 2},
                new MovieMovieGenre {MovieId = 3, MovieGenreId = 3}
            });

            context.Users.AddRange( new[] {
                new User {Id = 1, UserName = "test1", UserId = "test-1"},
                new User {Id = 2, UserName = "test2"},
                new User {Id = 3, UserName = "test3"}
            });

            context.UserMovies.AddRange( new[] {
                new UserMovie {MovieId = 2, UserId = 2, UserMovieStatusId = 3},
                new UserMovie {MovieId = 3, UserId = 2, UserMovieStatusId = 3}
            });

            context.SaveChanges();
        }
    }
}