using Application;
using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using AutoMapper;
using Infrastructure.Dal;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicStoreFront.Forms;

namespace MusicStoreFront
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var userService = scope.ServiceProvider.GetRequiredService<UserService>();

            CancellationToken cancellationToken = new CancellationToken();
                    
            System.Windows.Forms.Application.Run(new LoginForm(userService, cancellationToken));
        }
        
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MusicStoreDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=MusicStore;Username=postgres;Password=7733"));

            services.AddAutoMapper(typeof(UserMappingProfile));
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<GoogleCloudService>();
            
            var secretKey = "MISTRESS OF THE BLEEDING SORROW IS THE BEST DISSECTION SONG";
            services.AddScoped<UserService>(provider =>
            {
                var userRepository = provider.GetRequiredService<IUserRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                var googleCloud = new GoogleCloudService();
                return new UserService(userRepository, mapper, secretKey, googleCloud);
            });
        }
    }
}