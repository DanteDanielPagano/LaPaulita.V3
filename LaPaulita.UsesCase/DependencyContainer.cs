namespace LaPaulita.Sales.UsesCase
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServicesUseCase(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderInputPort, CreateOrderIteractor>();

            return services;
        }
    }
}
