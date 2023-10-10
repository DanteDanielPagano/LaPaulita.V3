using LaPaulita.Sales.WebApi;

var builder = WebApplication.CreateBuilder(args)
    .CreateWebApplication()
    .ConfigureWebApplication();
builder.Run();
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();
