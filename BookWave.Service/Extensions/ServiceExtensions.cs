using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;
using BookWave.Service.Abstract;
using BookWave.Service.Concrete;
using BookWave.Service.Settings;
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

        // AWS S3 Configuration
        var awsConfig = new AWSServiceSetting();
        var awsSettingSection = configuration.GetSection("AWSS3Configuration");
        awsSettingSection.Bind(awsConfig);

        var awsOptions = new AWSOptions
        {
            Credentials = new BasicAWSCredentials(awsConfig.AccessKey, awsConfig.SecretKey),
            Region = RegionEndpoint.GetBySystemName(awsConfig.Region)
        };
        
        services.AddAWSService<IAmazonS3>(awsOptions);
        services.Configure<AWSServiceSetting>(awsSettingSection);


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
        services.AddScoped<IBlogService, BlogService>();

        return services;
    }
}