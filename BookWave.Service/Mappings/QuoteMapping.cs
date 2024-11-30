using AutoMapper;
using BookWave.Entity.Dtos.QuoteDtos;
using BookWave.Entity.Entities;

namespace BookWave.Service.Mappings;
public class QuoteMapping : Profile
{
    public QuoteMapping()
    {
        CreateMap<Quote, QuoteDto>().ReverseMap();
        CreateMap<Quote, CreateQuoteDto>().ReverseMap();
        CreateMap<Quote, UpdateQuoteDto>().ReverseMap();
    }
}