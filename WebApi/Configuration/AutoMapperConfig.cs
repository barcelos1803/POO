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
            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorViewModel, Author>();
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<List<User>, IList<UserViewModel>>()
                .ConvertUsing((src, dest, context) => src.Select(user => context.Mapper.Map<UserViewModel>(user)).ToList());
        }
    }
}