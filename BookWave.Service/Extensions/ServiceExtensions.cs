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
        // Jwt
        //services.AddAuthentication(options =>
        //{
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //}).AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = configuration["Jwt:Issuer"],
        //        ValidAudience = configuration["Jwt:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        //    };
        //});


        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Services
        //services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookGenreService, BookGenreService>();
        services.AddScoped<IQuoteService, QuoteService>();

        return services;
    }
}