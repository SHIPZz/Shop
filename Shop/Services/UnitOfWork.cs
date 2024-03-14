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

        public BaseRepository<TEntity> Resolve<T, TEntity>() where T : BaseRepository<TEntity> where TEntity : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new BaseRepository<TEntity>(_context);
                _repositories[typeof(T)] = repository;
                return repository;
            }

            return (BaseRepository<TEntity>)_repositories[typeof(T)];
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}