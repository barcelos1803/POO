using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        private IAuthorRepository _AuthorRepository;
        private IBookRepository _BookRepository;
        private IUserRepository _UserRepository;

        public IAuthorRepository AuthorRepository
        {
            get { return _AuthorRepository ??= new AuthorRepository(_context); }
        }
        public IBookRepository BookRepository
        {
            get { return _BookRepository ??= new BookRepository(_context); }
        }
        public IUserRepository UserRepository
        {
            get { return _UserRepository ??= new UserRepository(_context); }
        }
    }
}