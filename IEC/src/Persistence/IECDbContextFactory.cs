using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class IECDbContextFactory : DesignTimeDbContextFactoryBase<IECDbContext>
    {
        protected override IECDbContext CreateNewInstance(DbContextOptions<IECDbContext> options)
        {
            return new IECDbContext(options);
        }
    }
}