using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
       Task<IList<Book>> GetBorrowedBooks();
       Task<IList<Book>> GetAuthorBooks(int AuthorId);
       Task<Book> GetAuthorsBook(int id);
    }
}