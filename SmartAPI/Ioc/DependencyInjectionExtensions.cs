using SmartAPI.Services.Interface;
using SmartAPI.Services;
using SmartAPI.Repository.Interface;
using SmartAPI.Repository;

namespace SmartAPI.Ioc {
    public class DependencyInjectionExtensions {
        public static IServiceCollection ConfigureServiceDependencies(IServiceCollection services) {
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
