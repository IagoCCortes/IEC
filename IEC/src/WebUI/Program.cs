using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.System.Commands.SeedSampleData;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var iecContext = services.GetRequiredService<IECDbContext>();
                    iecContext.Database.Migrate();

                    await IECDbContextSeed.SeedAsync(iecContext);

                    // var mediator = services.GetRequiredService<IMediator>();
                    // await mediator.Send(new SeedSampleDataCommand(), CancellationToken.None);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // .ConfigureLogging((context, logging) => {
                //     logging.ClearProviders();
                //     logging.AddConfiguration(context.Configuration.GetSection("logging"));
                //     logging.AddDebug();
                //     logging.AddConsole();
                // })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
