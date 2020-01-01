using System;
using Application.Artists.Commands.CreateArtist;
using Application.Artists.Commands.UpdateArtist;
using Application.Common.Mappings;
using AutoMapper;
using Persistence;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly IECDbContext Context;
        protected readonly IMapper Mapper;

        public CommandTestBase()
        {
            Context = IECContextFactory.Create();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CreateArtistCommandMapping());
                cfg.AddProfile(new UpdateArtistCommandMapping());
                // cfg.AddProfile(new UpdateArtistCommandMapping());
            });
            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            IECContextFactory.Destroy(Context);
        }
    }
}