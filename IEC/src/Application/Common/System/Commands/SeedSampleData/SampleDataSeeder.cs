using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Common.System.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly IIECDbContext _context;

        private readonly Dictionary<int, Artist> Artists = new Dictionary<int, Artist>();
        private readonly Dictionary<int, Movie> Movies = new Dictionary<int, Movie>();
        private readonly Dictionary<int, MovieGenre> MovieGenres = new Dictionary<int, MovieGenre>();
        private readonly Dictionary<int, MovieRole> MovieRoles = new Dictionary<int, MovieRole>();
        private readonly Dictionary<int, MovieArtist> MovieArtists = new Dictionary<int, MovieArtist>();
        private readonly Dictionary<int, MovieMovieGenre> MovieMovieGenres = new Dictionary<int, MovieMovieGenre>();

        public SampleDataSeeder(IIECDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.Artists.Any())
                return;

            await SeedArtistsAsync(cancellationToken);

            await SeedMoviesAsync(cancellationToken);

            await SeedMovieGenresAsync(cancellationToken);

            await SeedMovieRolesAsync(cancellationToken);

            await SeedMovieArtistsAsync(cancellationToken);

            await SeedMovieMovieGenresAsync(cancellationToken);
        }

        private async Task SeedArtistsAsync(CancellationToken cancellationToken)
        {
            var artists = new[]
            {
                new Artist { Id = 1, ArtistName = "Amy Adams", RealName = "Amy Lou Adams", Birthdate = DateTime.Parse("1974-08-20 00:00:00"), Birthplace = "Vicenza, Veneto, Italy", Height = 163, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTg2NTk2MTgxMV5BMl5BanBnXkFtZTgwNjcxMjAzMTI@._V1_SY1000_CR0,0,654,1000_AL_.jpg"},
                new Artist { Id = 2, ArtistName = "Robert Downey Jr.", RealName = "Robert John Downey Jr", Birthdate = DateTime.Parse("1965-04-04"), Birthplace = "Manhattan, New York City, New York, USA", Height = 174, PictureUrl = "https://m.media-amazon.com/images/M/MV5BNzg1MTUyNDYxOF5BMl5BanBnXkFtZTgwNTQ4MTE2MjE@._V1_SY1000_CR0,0,664,1000_AL_.jpg"},
                new Artist { Id = 3, ArtistName = "Keanu Reeves", RealName = "Keanu Charles Reeves", Birthdate = DateTime.Parse("1964-09-02"), Birthplace = "Beirut, Lebanon", Height = 186, PictureUrl = "https://m.media-amazon.com/images/M/MV5BNjUxNDcwMTg4Ml5BMl5BanBnXkFtZTcwMjU4NDYyOA@@._V1_SY1000_CR0,0,771,1000_AL_.jpg"},
                new Artist { Id = 4, ArtistName = "Halle Berry", RealName = "Maria Halle Berry", Birthdate = DateTime.Parse("1966-08-14"), Birthplace = "", Height = 166, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMjIxNzc5MDAzOV5BMl5BanBnXkFtZTcwMDUxMjMxMw@@._V1_.jpg"},
                new Artist { Id = 5, ArtistName = "Derek Kolstad", RealName = "", Birthdate = null, Birthplace = "", Height = 166, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMjE2NTI0NDYzNF5BMl5BanBnXkFtZTgwMDQ0NzEzMDI@._V1_SY1000_CR0,0,666,1000_AL_.jpg"},
                new Artist { Id = 6, ArtistName = "Chad Stahelski", RealName = "Charles F. Stahelski", Birthdate = DateTime.Parse("1968-09-20"), Birthplace = "USA", Height = 185, PictureUrl = "https://m.media-amazon.com/images/M/MV5BNjgwNzc0NTc2Nl5BMl5BanBnXkFtZTgwMjM0NzEzMDI@._V1_SY1000_CR0,0,666,1000_AL_.jpg"},
                new Artist { Id = 7, ArtistName = "Ryan Gosling", RealName = "Ryan Thomas Gosling", Birthdate = DateTime.Parse("1980-11-12"), Birthplace = "London, Ontario, Canada", Height = 184, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTQzMjkwNTQ2OF5BMl5BanBnXkFtZTgwNTQ4MTQ4MTE@._V1_SY1000_CR0,0,790,1000_AL_.jpg"},
                new Artist { Id = 8, ArtistName = "Harrison Ford", RealName = "", Birthdate = DateTime.Parse("1942-07-13"), Birthplace = "Chicago, Illinois, USA", Height = 183, PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTY4Mjg0NjIxOV5BMl5BanBnXkFtZTcwMTM2NTI3MQ@@._V1_.jpg"}
            };

            _context.Artists.AddRange(artists);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMoviesAsync(CancellationToken cancellationToken)
        {
            var movies = new[]
            {
                new Movie { Id = 1, Title = "The Irishman", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMGUyM2ZiZmUtMWY0OC00NTQ4LThkOGUtNjY2NjkzMDJiMWMwXkEyXkFqcGdeQXVyMzY0MTE3NzU@._V1_SY1000_CR0,0,682,1000_AL_.jpg", Runtime = 209, ReleaseDate = DateTime.Parse("2019-11-27"), Plot = "A mob hitman recalls his possible involvement with the slaying of Jimmy Hoffa."},
                new Movie { Id = 2, Title = "The Dark Knight", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg", Runtime = 152, ReleaseDate = DateTime.Parse("2008-07-18"), Plot = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."},
                new Movie { Id = 3, Title = "Nocturnal Animals", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTYwMzMwMzgxNl5BMl5BanBnXkFtZTgwMTA0MTUzMDI@._V1_SX300.jpg", Runtime = 116, ReleaseDate = DateTime.Parse("2016-12-09"), Plot = "A wealthy art gallery owner is haunted by her ex-husband''s novel, a violent thriller she interprets as a symbolic revenge tale."},
                new Movie { Id = 4, Title = "Arrival", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTExMzU0ODcxNDheQTJeQWpwZ15BbWU4MDE1OTI4MzAy._V1_SY1000_CR0,0,640,1000_AL_.jpg", Runtime = 116, ReleaseDate = DateTime.Parse("2016-11-11"), Plot = "A linguist works with the military to communicate with alien lifeforms after twelve mysterious spacecraft appear around the world."},
                new Movie { Id = 5, Title = "The Big Lebowski", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTQ0NjUzMDMyOF5BMl5BanBnXkFtZTgwODA1OTU0MDE@._V1_SY1000_CR0,0,670,1000_AL_.jpg", Runtime = 117, ReleaseDate = DateTime.Parse("1998-03-06"), Plot = "Jeff The Dude Lebowski, mistaken for a millionaire of the same name, seeks restitution for his ruined rug and enlists his bowling buddies to help get it."},
                new Movie { Id = 6, Title = "Inglourious Basterds", PosterUrl = "https://m.media-amazon.com/images/M/MV5BOTJiNDEzOWYtMTVjOC00ZjlmLWE0NGMtZmE1OWVmZDQ2OWJhXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_SY1000_SX675_AL_.jpg", Runtime = 153, ReleaseDate = DateTime.Parse("2009-08-21"), Plot = "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner''s vengeful plans for the same."},
                new Movie { Id = 7, Title = "Pulp Fiction", PosterUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,686,1000_AL_.jpg", Runtime = 154, ReleaseDate = DateTime.Parse("1994-10-14"), Plot = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption."},
                new Movie { Id = 8, Title = "Avengers: Endgame", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg", Runtime = 181, ReleaseDate = DateTime.Parse("2019-04-26"), Plot = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos'' actions and restore balance to the universe."},
                new Movie { Id = 9, Title = "The Matrix", PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg", Runtime = 136, ReleaseDate = DateTime.Parse("1999-03-31"), Plot = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers."},
                new Movie { Id = 10, Title = "Blade Runner 2049", PosterUrl = "https://m.media-amazon.com/images/M/MV5BNzA1Njg4NzYxOV5BMl5BanBnXkFtZTgwODk5NjU3MzI@._V1_SY1000_CR0,0,674,1000_AL_.jpg", Runtime = 166, ReleaseDate = DateTime.Parse("2017-10-06"), Plot = "A young blade runner''s discovery of a long-buried secret leads him to track down former blade runner Rick Deckard, who''s been missing for thirty years."},
                new Movie { Id = 11, Title = "John Wick: Chapter 3 - Parabellum", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMDg2YzI0ODctYjliMy00NTU0LTkxODYtYTNkNjQwMzVmOTcxXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_SY1000_CR0,0,648,1000_AL_.jpg", Runtime = 131, ReleaseDate = DateTime.Parse("2019-05-17"), Plot = "John Wick is on the run after killing a member of the international assassin''s guild, and with a $14 million price tag on his head, he is the target of hit men and women everywhere."},
                new Movie { Id = 11, Title = "300", PosterUrl = "https://m.media-amazon.com/images/M/MV5BMjc4OTc0ODgwNV5BMl5BanBnXkFtZTcwNjM1ODE0MQ@@._V1_SY1000_SX675_AL_.jpg", Runtime = 117, ReleaseDate = DateTime.Parse("2007-03-09"), Plot = "King Leonidas of Sparta and a force of 300 men fight the Persians at Thermopylae in 480 B.C."}
            };

            _context.Movies.AddRange(movies);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMovieGenresAsync(CancellationToken cancellationToken)
        {
            var genreNames = new[] {"Action", "Adventure", "Animation", "Biography", "Comedy", "Crime",
                         "Documentary", "Drama", "Family", "Fantasy", "Film Noir", "History",
                         "Horror", "Music", "Musical", "Mystery", "Romance", "Sci-Fi", "Short Film",
                         "Sport", "Superhero", "Thriller", "War", "Western"};

            var genres = new[]
            {
                new MovieGenre { Id = 1, Genre = genreNames[0]},
                new MovieGenre { Id = 2, Genre = genreNames[1]},
                new MovieGenre { Id = 3, Genre = genreNames[2]},
                new MovieGenre { Id = 4, Genre = genreNames[3]},
                new MovieGenre { Id = 5, Genre = genreNames[4]},
                new MovieGenre { Id = 6, Genre = genreNames[5]},
                new MovieGenre { Id = 7, Genre = genreNames[6]},
                new MovieGenre { Id = 8, Genre = genreNames[7]},
                new MovieGenre { Id = 9, Genre = genreNames[8]},
                new MovieGenre { Id = 10, Genre = genreNames[9]},
                new MovieGenre { Id = 11, Genre = genreNames[10]},
                new MovieGenre { Id = 12, Genre = genreNames[11]},
                new MovieGenre { Id = 13, Genre = genreNames[12]},
                new MovieGenre { Id = 14, Genre = genreNames[13]},
                new MovieGenre { Id = 15, Genre = genreNames[14]},
                new MovieGenre { Id = 16, Genre = genreNames[15]},
                new MovieGenre { Id = 17, Genre = genreNames[16]},
                new MovieGenre { Id = 18, Genre = genreNames[17]},
                new MovieGenre { Id = 19, Genre = genreNames[18]},
                new MovieGenre { Id = 20, Genre = genreNames[19]},
                new MovieGenre { Id = 21, Genre = genreNames[20]},
                new MovieGenre { Id = 22, Genre = genreNames[21]},
                new MovieGenre { Id = 23, Genre = genreNames[22]},
                new MovieGenre { Id = 24, Genre = genreNames[23]}
            };

            _context.MovieGenres.AddRange(genres);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMovieRolesAsync(CancellationToken cancellationToken)
        {
            var roles = new[]
            {
                new MovieRole { Id = 1, Role = "Star"},
                new MovieRole { Id = 2, Role = "Director"},
                new MovieRole { Id = 3, Role = "Writer"}
            };

            _context.MovieRoles.AddRange(roles);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMovieArtistsAsync(CancellationToken cancellationToken)
        {
            var movieArtists = new[]
            {
                new MovieArtist { MovieId = 11, ArtistId = 3, RoleId = 1},
                new MovieArtist { MovieId = 11, ArtistId = 4, RoleId = 1},
                new MovieArtist { MovieId = 11, ArtistId = 6, RoleId = 2},
                new MovieArtist { MovieId = 11, ArtistId = 5, RoleId = 3},
                new MovieArtist { MovieId = 3, ArtistId = 1, RoleId = 1},
                new MovieArtist { MovieId = 4, ArtistId = 1, RoleId = 1},
                new MovieArtist { MovieId = 9, ArtistId = 3, RoleId = 1},
                new MovieArtist { MovieId = 8, ArtistId = 2, RoleId = 1},
                new MovieArtist { MovieId = 10, ArtistId = 7, RoleId = 1}
            };

            _context.MovieArtists.AddRange(movieArtists);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedMovieMovieGenresAsync(CancellationToken cancellationToken)
        {
            var movieMovieGenres = new[]
            {
                new MovieMovieGenre { MovieId = 1, MovieGenreId = 6},
                new MovieMovieGenre { MovieId = 1, MovieGenreId = 4},
                new MovieMovieGenre { MovieId = 2, MovieGenreId = 1},
                new MovieMovieGenre { MovieId = 2, MovieGenreId = 6},
                new MovieMovieGenre { MovieId = 2, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 3, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 3, MovieGenreId = 22},
                new MovieMovieGenre { MovieId = 4, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 4, MovieGenreId = 16},
                new MovieMovieGenre { MovieId = 4, MovieGenreId = 18},
                new MovieMovieGenre { MovieId = 5, MovieGenreId = 5},
                new MovieMovieGenre { MovieId = 5, MovieGenreId = 6},
                new MovieMovieGenre { MovieId = 5, MovieGenreId = 20},
                new MovieMovieGenre { MovieId = 6, MovieGenreId = 2},
                new MovieMovieGenre { MovieId = 6, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 6, MovieGenreId = 23},
                new MovieMovieGenre { MovieId = 7, MovieGenreId = 1},
                new MovieMovieGenre { MovieId = 7, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 8, MovieGenreId = 1},
                new MovieMovieGenre { MovieId = 8, MovieGenreId = 2},
                new MovieMovieGenre { MovieId = 8, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 9, MovieGenreId = 1},
                new MovieMovieGenre { MovieId = 9, MovieGenreId = 18},
                new MovieMovieGenre { MovieId = 10, MovieGenreId = 1},
                new MovieMovieGenre { MovieId = 10, MovieGenreId = 8},
                new MovieMovieGenre { MovieId = 10, MovieGenreId = 16},
                new MovieMovieGenre { MovieId = 11, MovieGenreId = 1},
                new MovieMovieGenre { MovieId = 11, MovieGenreId = 6},
                new MovieMovieGenre { MovieId = 11, MovieGenreId = 22}
            };
            
            _context.MovieMovieGenres.AddRange(movieMovieGenres);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}