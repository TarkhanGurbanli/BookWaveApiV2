using AutoMapper;
using BookWave.Entity.Dtos.GenreDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class GenreMapping : Profile
{
    public GenreMapping()
    {
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<Genre, CreateGenreDto>().ReverseMap();
        CreateMap<Genre, UpdateGenreDto>().ReverseMap();
    }
}