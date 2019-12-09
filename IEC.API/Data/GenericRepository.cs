using System.Threading.Tasks;

namespace IEC.API.Data
{
    public abstract class GenericRepository : IGenericRepository
    {
        protected DataContext Context;

        public GenericRepository(DataContext context)
        {
            Context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}