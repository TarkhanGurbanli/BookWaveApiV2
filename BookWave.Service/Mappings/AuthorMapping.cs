using AutoMapper;
using BookWave.Entity.Dtos.AuthorDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class AuthorMapping : Profile
{
    public AuthorMapping()
    {
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, CreateAuthorDto>().ReverseMap();
        CreateMap<Author, UpdateAuthorDto>().ReverseMap();
    }
}