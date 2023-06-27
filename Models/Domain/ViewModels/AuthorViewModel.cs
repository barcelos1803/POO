using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class AuthorViewModel
    {
        
        public IList<BookViewModel> Books { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
}