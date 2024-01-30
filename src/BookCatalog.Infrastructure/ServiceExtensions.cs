using BookCatalog.Application.Interface;
using BookCatalog.Application.Services;
using BookCatalog.Application.Services.Interface;
using BookCatalog.Infrastructure.Context;
using BookCatalog.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookCatalogDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("connectionString"));
            });
        }

        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
        }

        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.ConfigureDI();
        }
    }
}
