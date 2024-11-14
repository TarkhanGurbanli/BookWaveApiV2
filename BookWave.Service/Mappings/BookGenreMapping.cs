using AutoMapper;
using BookWave.Dto.BookGenreDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class BookGenreMapping : Profile
{
    public BookGenreMapping()
    {
        CreateMap<BookGenre, BookGenreDto>().ReverseMap();
        CreateMap<BookGenre, CreateBookGenreDto>().ReverseMap();
        CreateMap<BookGenre, UpdateBookGenreDto>().ReverseMap();
    }
}
