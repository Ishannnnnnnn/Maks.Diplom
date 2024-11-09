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
            var orderService = scope.ServiceProvider.GetRequiredService<OrderService>();
            var instrumentService = scope.ServiceProvider.GetRequiredService<InstrumentService>();
            var storeService = scope.ServiceProvider.GetRequiredService<StoreService>();
            
            var orderInstrumentService = scope.ServiceProvider.GetRequiredService<OrderInstrumentService>();

            CancellationToken cancellationToken = new CancellationToken();
                    
            System.Windows.Forms.Application.Run(new LoginForm(
                userService,
                orderService,
                orderInstrumentService,
                instrumentService,
                storeService,
                cancellationToken));
        }
        
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MusicStoreDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=MusicStore;Username=postgres;Password=7733"));

            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddAutoMapper(typeof(InstrumentMappingProfile));
            services.AddAutoMapper(typeof(OrderMappingProfile));
            services.AddAutoMapper(typeof(StoreMappingProfile));
            
            services.AddAutoMapper(typeof(OrderInstrumentMappingProfile));
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            
            services.AddScoped<IOrderInstrumentRepository, OrderInstrumentRepository>();
            
            services.AddScoped<UserService>();
            services.AddScoped<OrderService>();
            services.AddScoped<InstrumentService>();
            services.AddScoped<StoreService>();
            
            services.AddScoped<OrderInstrumentService>();
            services.AddScoped<GoogleCloudService>();
            
            var secretKey = "MISTRESS OF THE BLEEDING SORROW IS THE BEST DISSECTION SONG";
            services.AddScoped<UserService>(provider =>
            {
                var userRepository = provider.GetRequiredService<IUserRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                var googleCloud = new GoogleCloudService();
                return new UserService(userRepository, mapper, secretKey, googleCloud);
            });
            
            services.AddScoped<OrderService>(provider =>
            {
                var orderRepository = provider.GetRequiredService<IOrderRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new OrderService(orderRepository, mapper);
            });
            
            services.AddScoped<InstrumentService>(provider =>
            {
                var instrumentRepository = provider.GetRequiredService<IInstrumentRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                var googleCloud = new GoogleCloudService();
                return new InstrumentService(instrumentRepository, mapper, googleCloud);
            });
            
            services.AddScoped<StoreService>(provider =>
            {
                var storeRepository = provider.GetRequiredService<IStoreRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new StoreService(storeRepository, mapper);
            });
            
            services.AddScoped<OrderInstrumentService>(provider =>
            {
                var orderInstrumentRepository = provider.GetRequiredService<IOrderInstrumentRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new OrderInstrumentService(orderInstrumentRepository, mapper);
            });
        }
    }
}