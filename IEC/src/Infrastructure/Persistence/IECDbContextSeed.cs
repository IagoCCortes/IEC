using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Newtonsoft.Json;

namespace Infrastructure.Persistence
{
    public static class IECDbContextSeed
    {
        public static async Task SeedAsync(IECDbContext context)
        { 
            if(!context.Artists.Any())
            {
                await context.AddRangeAsync(EntityData<Artist>("artists"));
                await context.AddRangeAsync(EntityData<Movie>("movies"));
                await context.AddRangeAsync(EntityData<MovieGenre>("movieGenres"));
                await context.AddRangeAsync(EntityData<MovieRole>("movieRoles"));
                await context.AddRangeAsync(EntityData<UserProfileMovieStatus>("userProfileMovieStatuses"));
                await context.SaveChangesAsync();

                await context.AddRangeAsync(EntityData<MovieMovieGenre>("movieMovieGenres"));
                await context.AddRangeAsync(EntityData<MovieArtist>("movieArtists"));
                await context.SaveChangesAsync();
            }
        }

        public static List<T> EntityData<T>(string entity)
        {
            var entityData = System.IO.File.ReadAllText("../Infrastructure/Persistence/SeedData/" + entity + ".json");
            return JsonConvert.DeserializeObject<List<T>>(entityData);
        }
    }
}