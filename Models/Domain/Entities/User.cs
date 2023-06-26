namespace Domain.Entities
{
    public class User : Entity
    {
        public string Nome { get; set; }

        /* EF Relations */
        public IList<Book> BorrowedBooks { get; set; }
    }
}