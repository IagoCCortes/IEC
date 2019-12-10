using System;
using System.Threading.Tasks;
using IEC.API.Core.Repositories;

namespace IEC.API.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IArtistRepository Artists { get; }
        IMovieMovieGenreRepository MovieMovieGenres { get; }
        Task<bool> CompleteAsync();
    }
}