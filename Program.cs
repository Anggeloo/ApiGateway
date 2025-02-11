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
    c.SwaggerEndpoint("/workTeam/swagger/doc.json", "WorkTeam Search");
    c.SwaggerEndpoint("/workTeamAdd/swagger/doc.json", "WorkTeam Add");
    c.SwaggerEndpoint("/workTeamUpdate/swagger/doc.json", "WorkTeam Update");
    c.SwaggerEndpoint("/workTeamDelete/swagger/doc.json", "WorkTeam Delete");
    c.SwaggerEndpoint("/order/swagger/v1/swagger.json", "Order Search");
    c.SwaggerEndpoint("/orderAdd/swagger/v1/swagger.json", "Order Add");
    c.SwaggerEndpoint("/orderUpdate/swagger/v1/swagger.json", "Order Update");
    c.SwaggerEndpoint("/orderDelete/swagger/v1/swagger.json", "Order Delete");

    c.SwaggerEndpoint("/informationGraphics/swagger/v1/swagger.json", "Information Graphics");
    c.SwaggerEndpoint("/summaryMountry/swagger/v1/swagger.json", "Monthly Summary");
    c.SwaggerEndpoint("/materialManagement/swagger/v1/swagger.json", "Raw Material Management");
    c.SwaggerEndpoint("/teamPerformance/swagger/v1/swagger.json", "Team Performance Analysis");
});

await app.UseOcelot();

app.Run();
