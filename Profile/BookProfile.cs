using AutoMapper;
using PracticeTest.DTO;
using PracticeTest.Entities;

namespace PracticeTest.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}
