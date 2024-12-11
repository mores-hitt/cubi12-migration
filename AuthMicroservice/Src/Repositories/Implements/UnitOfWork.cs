using Auth.Src.Data;
using Auth.Src.Repositories.Interfaces;
namespace Auth.Src.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICareersRepository _careersRepository = null!;
        private IRolesRepository _rolesRepository = null!;
        private IUsersRepository _usersRepository = null!;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private readonly DataContext _context;
        private bool _disposed = false;

        public ICareersRepository CareersRepository
        {
            get
            {
                _careersRepository ??= new CareersRepository(_context);
                return _careersRepository;
            }
        }

        public IRolesRepository RolesRepository
        {
            get
            {
                _rolesRepository ??= new RolesRepository(_context);
                return _rolesRepository;
            }
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                _usersRepository ??= new UsersRepository(_context);
                return _usersRepository;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}