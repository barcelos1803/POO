using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.ViewModels;

namespace WebApi.Configuration
{
    public class AutoMapperDTOs : Profile
    {
        public AutoMapperDTOs()
        {
            CreateMap<Author, AuthorsDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<Book, BookDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<User, UserDTO>().PreserveReferences().MaxDepth(0);
        }
    }

    public class AutoMapperViewModels : Profile
    {
        public AutoMapperViewModels()
        {
            CreateMap<AuthorViewModel, Author>();
            CreateMap<BookViewModel, Book>();
            CreateMap<UserViewModel, User>();
        }
    }
}