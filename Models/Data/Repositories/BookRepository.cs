using System.Linq.Expressions;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int entityId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == entityId);

            if (book == null)
                return false;
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IList<Book>> GetAuthorBooks(int AuthorId)
        {
            return (IList<Book>)await _context.Books.AsNoTracking()
            .Include(g => g.Authors)
            .FirstOrDefaultAsync(x => x.Id == AuthorId);
        }

        public async Task<Book> GetAuthorsBook(int id)
        {
            return await _context.Books.AsNoTracking()
                .Include(j => j.Authors)
                .FirstOrDefaultAsync(x => x.Id == id);          
        }

        public async Task<IList<Book>> GetBorrowedBooks()
        {
            return await _context.Books.AsNoTracking()
                .Include(g => g.Authors)
                .OrderBy(x => x.Titulo)
                .ToListAsync();  
        }

        public async Task<Book> GetByIdAsync(int entityId)
        {
            return await _context.Books
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();

        }

        public async Task<IList<Book>> SearchAll(Expression<Func<Book, bool>> predicate)
        {
            return await _context.Books.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Update(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}