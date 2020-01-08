using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Infrastructure.Persistence
{
    public static class IECDbContextSeed
    {
        public static async Task SeedAsync(IECDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
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

                var roles = new List<IdentityRole> {
                    new IdentityRole {Name = "Member"},
                    new IdentityRole {Name = "Admin"},
                    new IdentityRole {Name = "Moderator"},
                    new IdentityRole {Name = "VIP"}
                };

                foreach (var role in roles)
                    await roleManager.CreateAsync(role);

                var adminUser = new ApplicationUser {UserName = "admin", Email = "admin@gmail.com"};
                var memberUser = new ApplicationUser {UserName = "member", Email = "member@gmail.com"};
                var moderatorUser = new ApplicationUser {UserName = "moderator", Email = "moderator@gmail.com"};
                var vipUser = new ApplicationUser {UserName = "vip", Email = "vip@gmail.com"};
                await userManager.CreateAsync(adminUser, "admin");
                await userManager.AddToRolesAsync(adminUser, new [] {"Admin", "Moderator"});
                await userManager.CreateAsync(memberUser, "member");
                await userManager.AddToRoleAsync(memberUser, "Member");
                await userManager.CreateAsync(moderatorUser, "moderator");
                await userManager.AddToRoleAsync(moderatorUser, "Moderator");
                await userManager.CreateAsync(vipUser, "vipp");
                await userManager.AddToRoleAsync(vipUser, "VIP");

                await context.AddAsync(new UserProfile { UserId = adminUser.Id, UserName = adminUser.UserName });
                await context.AddAsync(new UserProfile { UserId = memberUser.Id, UserName = memberUser.UserName });
                await context.AddAsync(new UserProfile { UserId = moderatorUser.Id, UserName = moderatorUser.UserName });
                await context.AddAsync(new UserProfile { UserId = vipUser.Id, UserName = vipUser.UserName });
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