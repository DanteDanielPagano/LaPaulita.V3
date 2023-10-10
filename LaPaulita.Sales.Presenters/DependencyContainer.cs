namespace LaPaulita.Sales.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServicesPresenter(this IServiceCollection services)
        {
            services.AddScoped<CreateOrderPresenter>();

            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

            services.AddScoped<ICreateOrderPresenter, CreateOrderPresenter>();

            return services;
        }
    }
}
