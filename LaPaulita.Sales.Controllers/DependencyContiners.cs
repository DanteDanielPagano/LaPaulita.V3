namespace LaPaulita.Sales.Controllers
{
    public static class DependencyContiners
    {
        public static IServiceCollection AddServicesSalesControllers(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderController, CreateOrderController>();
            return services;
        }
    }
}
