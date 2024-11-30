using AutoMapper;
using BookWave.Entity.Dtos.PublisherDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class PublisherMapping : Profile
{
    public PublisherMapping()
    {
        CreateMap<Publisher, PublisherDto>().ReverseMap();
        CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
        CreateMap<Publisher, UpdatePublisherDto>().ReverseMap();
    }
}
