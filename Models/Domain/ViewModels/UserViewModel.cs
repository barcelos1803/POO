using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public IList<BookViewModel> BorrowedBooks { get; set; }
    }
}