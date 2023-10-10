
namespace DependencyInversion
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLaPaulitaSalesServices(this IServiceCollection services, IConfiguration configuration, string ConnectionString)
        {
            services
                .AddRepositories(configuration, ConnectionString)
                .AddServicesUseCase()
                .AddServicesPresenter()
                .AddServicesSalesControllers();

            return services;
        }
    }
}
