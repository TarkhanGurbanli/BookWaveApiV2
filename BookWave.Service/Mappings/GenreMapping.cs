using AutoMapper;
using BookWave.Entity.Dtos.GenreDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class GenreMapping : Profile
{
    public GenreMapping()
    {
        CreateMap<Category, GenreDto>().ReverseMap();
        CreateMap<Category, CreateGenreDto>().ReverseMap();
        CreateMap<Category, UpdateGenreDto>().ReverseMap();
    }
}