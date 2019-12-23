using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Common;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class IECDbContext : DbContext, IIECDbContext
    {
        private readonly IDateTime _dateTime;

        public IECDbContext(DbContextOptions<IECDbContext> options)
            : base(options) { }

        public IECDbContext(DbContextOptions<IECDbContext> options, IDateTime dateTime)
        : base(options) 
        {
            _dateTime = dateTime;
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<MovieArtist> MovieArtists { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieMovieGenre> MovieMovieGenres { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        // entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        // entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IECDbContext).Assembly);
        }
    }
}