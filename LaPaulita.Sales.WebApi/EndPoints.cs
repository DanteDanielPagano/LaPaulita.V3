using LaPaulita.Sales.BusinessRules.DTOs;
using LaPaulita.Sales.BusinessRules.Interface.Controllers;

namespace LaPaulita.Sales.WebApi
{
    public static class EndPoints
    {
        public static WebApplication LaPaulitaSalesEndPoint(this WebApplication app)
        {
            app.MapPost("/create", async (OrderHeaderDto order, ICreateOrderController controller) =>
            {
                var result = await controller.CreateOrder(order);

                if (!string.IsNullOrEmpty(result.Message) || result.Errors != null)
                {
                    return Results.BadRequest(result);
                }
                else
                {
                    return Results.Ok(result);
                }

            });

            return app;
        }
    }
}
