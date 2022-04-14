using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PricefyChallenge.Core.Interfaces.Repository;
using PricefyChallenge.Core.Interfaces.Services;
using PricefyChallenge.Core.Services;
using PricefyChallenge.Infra.Repository;
using PricefyChallenge.Infra.Services;

namespace PricefyChallenge.Api.Ioc
{
    public static class Registers
    {
        public static IServiceCollection RegisterIoc(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieServices, MovieServices>();
            services.AddScoped<IFileServices, FileServices>();


            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Startup>>();
            services.AddSingleton(typeof(ILogger), logger);

            return services;
        }
    }
}
