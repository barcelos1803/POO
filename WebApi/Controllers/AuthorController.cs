using System.Linq.Expressions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            bool deleted = _authorRepository.Delete(id);

            if (deleted)
            {
                return HttpMessageOk();
            }
            else
            {
                return HttpMessageError("Failed to delete author.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorViewModels = authors.Select(a => new AuthorViewModel
            {
                // Mapeie as propriedades relevantes aqui
                Nome = a.Nome,
                // Mapeie outras propriedades conforme necessário
            }).ToList();
            
            return HttpMessageOk(authorViewModels);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author != null)
            {
                var authorViewModel = _mapper.Map<AuthorViewModel>(author);
                return HttpMessageOk(authorViewModel);
            }
            else
            {
                return HttpMessageError("Author not found.");
            }
        }

        [HttpPost]
        public IActionResult SaveAuthor(AuthorViewModel authorViewModel)
        {
            var author = _mapper.Map<Author>(authorViewModel);
            _authorRepository.Save(author);
            return HttpMessageOk();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateAuthor(int id, AuthorViewModel authorViewModel)
        {
            var author = _mapper.Map<Author>(authorViewModel);
            author.Id = id;
            _authorRepository.Update(author);
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
