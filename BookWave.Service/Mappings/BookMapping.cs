using AutoMapper;
using BookWave.Entity.Dtos.BookDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class BookMapping : Profile
{
    public BookMapping()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, CreateBookDto>().ReverseMap();
        CreateMap<Book, UpdateBookDto>().ReverseMap();
    }
}