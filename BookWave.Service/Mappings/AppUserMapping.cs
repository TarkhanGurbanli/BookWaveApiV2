using AutoMapper;
using BookWave.Dto.AuthDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class AppUserMapping : Profile
{
    public AppUserMapping()
    {
        CreateMap<AppUser, LoginDto>().ReverseMap();
        CreateMap<AppUser, RegisterDto>().ReverseMap();
    }
}
