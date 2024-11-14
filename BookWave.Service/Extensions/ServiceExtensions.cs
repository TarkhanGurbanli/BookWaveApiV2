using BookWave.Service.Abstract;
using BookWave.Service.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookWave.Service.Extensions;
public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Services
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookGenreService, BookGenreService>();
        services.AddScoped<IQuoteService, QuoteService>();

        return services;
    }
}
