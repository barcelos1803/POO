namespace Domain.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        /* EF Relations */
        public IList<AuthorsDTO> Authors { get; set; }        
    }
}