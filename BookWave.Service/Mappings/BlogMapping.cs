using AutoMapper;
using BookWave.Entity.Dtos.BlogDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class BlogMapping : Profile
{
    public BlogMapping()
    {
        CreateMap<Blog, BlogDto>().ReverseMap();
        CreateMap<Blog, CreateBlogDto>().ReverseMap();
        CreateMap<Blog, UpdateBlogDto>().ReverseMap();
    }
}
