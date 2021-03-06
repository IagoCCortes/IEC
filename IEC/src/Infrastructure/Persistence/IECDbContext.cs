using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class IECDbContext : IdentityDbContext<ApplicationUser>, IIECDbContext//ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public IECDbContext(DbContextOptions options, ICurrentUserService currentUserService, IDateTime dateTime) : base(options) 
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<MovieArtist> MovieArtists { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieMovieGenre> MovieMovieGenres { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserProfileFollowArtist> UserProfileFollowArtists { get; set; }
        public DbSet<UserProfileMovie> UserProfileMovies { get; set; }
        public DbSet<UserProfileMovieStatus> UserProfileMovieStatuses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IECDbContext).Assembly);
            // builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public IQueryable<T> GetQuery<T>(Type EntityType)
        {
            var pq = from p in this.GetType().GetProperties()
                    where p.PropertyType.IsGenericType
                        && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
                        && p.PropertyType.GenericTypeArguments[0] ==  EntityType
                    select p;
            var prop = pq.Single();

            return (IQueryable<T>)prop.GetValue(this);
        }

        public IQueryable<ISearchableEntity> SetDbSet(Type type)
        {
            return (IQueryable<ISearchableEntity>)this.Set(type);
        }
    }
}