using AutoMapper;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BookController(IBookRepository bookRepository, IMapper mapper, DataContext context)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            bool deleted = _bookRepository.Delete(id);

            if (deleted)
            {
                return HttpMessageOk();
            }
            else
            {
                return HttpMessageError("Failed to delete book.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            var bookViewModels = _mapper.Map<IList<BookViewModel>>(books);
            return HttpMessageOk(bookViewModels);
        }

        [HttpGet("Get-Author-Books/{id:int}")]
        public async Task<IActionResult> GetAuthorBooks(int id)
        {
            var books = await _bookRepository.GetAuthorBooks(id);
            var bookViewModels = _mapper.Map<IList<BookViewModel>>(books);
            return HttpMessageOk(bookViewModels);
        }

        [HttpGet("Get-Authors-Book/{id:int}")]
        public async Task<IActionResult> GetAuthorsBook(int id)
        {
            var book = await _bookRepository.GetAuthorsBook(id);

            if (book != null)
            {
                var bookViewModel = _mapper.Map<BookViewModel>(book);
                return HttpMessageOk(bookViewModel);
            }
            else
            {
                return HttpMessageError("Book not found.");
            }
        }

        [HttpGet("Get-Borrowed-Books")]
        public async Task<IActionResult> GetBorrowedBooks()
        {
            var books = await _bookRepository.GetBorrowedBooks();
            var bookViewModels = _mapper.Map<IList<BookViewModel>>(books);
            return HttpMessageOk(bookViewModels);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book != null)
            {
                var bookViewModel = _mapper.Map<BookViewModel>(book);
                return HttpMessageOk(bookViewModel);
            }
            else
            {
                return HttpMessageError("Book not found.");
            }
        }

        [HttpPost]
        public IActionResult SaveBook(BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            _bookRepository.Save(book);
            return HttpMessageOk();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            book.Id = id;
            _bookRepository.Update(book);
            return HttpMessageOk();
        }

        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(new
                {
                    data
                });
            }
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new
            {
                message
            });
        }
        [HttpPost("{bookId}/authors")]
        public async Task<IActionResult> AddAuthorToBook(int bookId, [FromBody] AuthorViewModel authorViewModel)
        {
            try
            {
                // Primeiro, verifique se o livro existe
                var book = await _context.Books.FindAsync(bookId);
                if (book == null)
                {
                    return NotFound("Livro não encontrado.");
                }

                // Mapeie o AuthorViewModel para o modelo de domínio Author
                var author = _mapper.Map<Author>(authorViewModel);

                // Verifique se o autor já está associado ao livro
                if (book.Authors.Contains(author))
                {
                    return BadRequest("O autor já está associado ao livro.");
                }

                // Adicione o autor ao livro
                book.Authors.Add(author);

                // Salve as alterações no banco de dados
                await _context.SaveChangesAsync();

                return Ok("Autor adicionado ao livro com sucesso.");
            }
            catch (Exception ex)
            {
                // Trate qualquer erro ocorrido durante o processo
                return StatusCode(500, $"Ocorreu um erro ao adicionar o autor ao livro: {ex.Message}");
            }
        }
    }
}
