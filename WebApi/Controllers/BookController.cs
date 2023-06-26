using AutoMapper;
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

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
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
    }
}
