using AutoMapper;
using BookWave.Entity.Dtos.BookGenreDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class BookGenreMapping : Profile
{
    public BookGenreMapping()
    {
        CreateMap<BookCategory, BookGenreDto>().ReverseMap();
        CreateMap<BookCategory, CreateBookGenreDto>().ReverseMap();
        CreateMap<BookCategory, UpdateBookGenreDto>().ReverseMap();
    }
}