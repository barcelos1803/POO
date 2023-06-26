using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class BookViewModel
    {
       public int UserId { get; set; }

       [Required(ErrorMessage = "O campo {0} é obrigatório")]
       public string Titulo { get; set; }

       [Required(ErrorMessage = "O campo {0} é obrigatório")]
       public string Descricao { get; set; }

       [Required(ErrorMessage = "O campo {0} é obrigatório")]
       public IList<AuthorViewModel> Authors { get; set; }
    }
}