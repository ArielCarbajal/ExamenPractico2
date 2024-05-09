using Microsoft.OpenApi.Models;
using Examen2.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de tienda", Description = "Ariel Enoc Carbajal Amaya", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de tienda V1");
    });
}

app.MapGet("/Productos/{id}", (int id) => TiendaDB.GetItem(id));
app.MapGet("/Productos", () => TiendaDB.GetItems());
app.MapPost("/Productos", (Items item) => TiendaDB.CreateItem(item));
app.MapPut("/Productos", (Items item) => TiendaDB.UpdateItem(item));
app.MapDelete("/Productos/{id}", (int id) => TiendaDB.RemoveItem(id));

app.Run();