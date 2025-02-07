using ApiGateway;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:5050");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Configuration.AddJsonFile("ocelot-dev.json");
//builder.Configuration.AddJsonFile("ocelot-prod.json");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOcelot();

//builder.Services.AddOcelot()
//    .AddDelegatingHandler<DebuggingHandler>(); //




var app = builder.Build();


app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/products/swagger.json", "Product Search");
    c.SwaggerEndpoint("/productsAdd/swagger.json", "Product Add");
    c.SwaggerEndpoint("/productsUpdate/swagger.json", "Product Update");
    c.SwaggerEndpoint("/productsDelete/swagger.json", "Product Delete");
    c.SwaggerEndpoint("/inventory/swagger.json", "Inventory Search");
    c.SwaggerEndpoint("/inventoryAdd/swagger.json", "Inventory Add");
    c.SwaggerEndpoint("/inventoryUpdate/swagger.json", "Inventory Update");
    c.SwaggerEndpoint("/inventoryDelate/swagger.json", "Inventory Delete");
});

await app.UseOcelot();

app.Run();
