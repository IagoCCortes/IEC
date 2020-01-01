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

            context.SaveChanges();
        }
    }
}