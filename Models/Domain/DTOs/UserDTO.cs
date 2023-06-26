namespace Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        /* EF Relations */
        public IList<BookDTO> BorrowedBooks { get; set; }        
    }
}