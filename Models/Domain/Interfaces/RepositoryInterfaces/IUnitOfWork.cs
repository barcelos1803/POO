namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();

        IUserRepository UserRepository {get;}
        IBookRepository BookRepository {get;}
        IAuthorRepository AuthorRepository {get;}
    }
}