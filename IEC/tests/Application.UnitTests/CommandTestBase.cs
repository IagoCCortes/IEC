using System;
using Application.Common.Mappings;
using AutoMapper;
using Infrastructure.Persistence;

namespace Application.UnitTests
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
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            IECContextFactory.Destroy(Context);
        }
    }
}