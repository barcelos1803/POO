namespace Domain.Entities
{
    public class Author : Entity
    {
        public string Nome { get; set; }

        /* EF Relations */
        public IList<Book> Books { get; set; }= new List<Book>();
    }
}