using Shop.Data;

namespace Shop.Services
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public BaseRepository<TEntity> Resolve<TBaseRepository, TEntity>() where TBaseRepository : BaseRepository<TEntity> where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(TBaseRepository)))
            {
                var repository = new BaseRepository<TEntity>(_context);
                _repositories[typeof(TBaseRepository)] = repository;
                return repository;
            }

            return (BaseRepository<TEntity>)_repositories[typeof(TBaseRepository)];
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}