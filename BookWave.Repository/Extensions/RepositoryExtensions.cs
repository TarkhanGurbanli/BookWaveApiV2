using BookWave.Repository.Abstract;
using BookWave.Repository.Concrete;
using BookWave.Repository.Context;
using BookWave.Repository.Settings;
using BookWave.Repository.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookWave.Repository.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration
            .GetSection(ConnectionStringSetting.Key)
            .Get<ConnectionStringSetting>();

            options.UseNpgsql(connectionString!.PostgreSQL, sqlServerOptionsAction =>
            {
                sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryExtensions).Assembly.FullName);
            });
        });

        // Generic
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //// UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        ////Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookGenreRepository, BookGenreRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IPhotoFileRepository, PhotoFileRepository>();
        services.AddScoped<IPubLisherRepository, PublisherRepository>();
        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IWishlistRepository, WishlistRepository>();

        return services;
    }
}