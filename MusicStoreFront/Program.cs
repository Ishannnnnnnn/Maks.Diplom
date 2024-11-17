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
            var instrumentStoreService = scope.ServiceProvider.GetRequiredService<InstrumentStoreService>();

            CancellationToken cancellationToken = new CancellationToken();
                    
            System.Windows.Forms.Application.Run(new LoginForm(
                userService,
                orderService,
                orderInstrumentService,
                instrumentStoreService,
                instrumentService,
                storeService,
                cancellationToken));
        }
        
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MusicStoreDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=MusicStore;Username=postgres;Password=7733"),
                ServiceLifetime.Transient);

            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddAutoMapper(typeof(InstrumentMappingProfile));
            services.AddAutoMapper(typeof(OrderMappingProfile));
            services.AddAutoMapper(typeof(StoreMappingProfile));
            
            services.AddAutoMapper(typeof(OrderInstrumentMappingProfile));
            services.AddAutoMapper(typeof(InstrumentStoreMappingProfile));
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IInstrumentRepository, InstrumentRepository>();
            services.AddTransient<IStoreRepository, StoreRepository>();
            
            services.AddTransient<IOrderInstrumentRepository, OrderInstrumentRepository>();
            services.AddTransient<IInstrumentStoreRepository, InstrumentStoreRepository>();
            
            services.AddTransient<UserService>();
            services.AddTransient<OrderService>();
            services.AddTransient<InstrumentService>();
            services.AddTransient<StoreService>();
            
            services.AddTransient<OrderInstrumentService>();
            services.AddTransient<InstrumentStoreService>();
            services.AddTransient<GoogleCloudService>();
            
            var secretKey = "MISTRESS OF THE BLEEDING SORROW IS THE BEST DISSECTION SONG";
            services.AddTransient<UserService>(provider =>
            {
                var userRepository = provider.GetRequiredService<IUserRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                var googleCloud = new GoogleCloudService();
                return new UserService(userRepository, mapper, secretKey, googleCloud);
            });
            
            services.AddTransient<OrderService>(provider =>
            {
                var orderRepository = provider.GetRequiredService<IOrderRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new OrderService(orderRepository, mapper);
            });
            
            services.AddTransient<InstrumentService>(provider =>
            {
                var instrumentRepository = provider.GetRequiredService<IInstrumentRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                var googleCloud = new GoogleCloudService();
                return new InstrumentService(instrumentRepository, mapper, googleCloud);
            });
            
            services.AddTransient<StoreService>(provider =>
            {
                var storeRepository = provider.GetRequiredService<IStoreRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new StoreService(storeRepository, mapper);
            });
            
            services.AddTransient<OrderInstrumentService>(provider =>
            {
                var orderInstrumentRepository = provider.GetRequiredService<IOrderInstrumentRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new OrderInstrumentService(orderInstrumentRepository, mapper);
            });
            
            services.AddTransient<InstrumentStoreService>(provider =>
            {
                var instrumentStoreRepository = provider.GetRequiredService<IInstrumentStoreRepository>();
                var mapper = provider.GetRequiredService<IMapper>();
                return new InstrumentStoreService(instrumentStoreRepository, mapper);
            });
        }
    }
}