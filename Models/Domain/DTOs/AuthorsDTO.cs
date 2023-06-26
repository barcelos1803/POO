namespace Domain.DTOs
{
    public class AuthorsDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        /* EF Relations */
        public IList<BookDTO> Books { get; set; }
    }
}