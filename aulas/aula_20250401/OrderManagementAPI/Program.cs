using OrderManagementAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

List<Order> orders = [
    new Order {Id = 1, Customer = "John", Amount = 150},
    new Order {Id = 2, Customer = "Mary", Amount = 200.5m}
];

app.MapGet("/orders", () => orders);
app.MapGet("/orders/{id}", (int id) => {
    var order = orders.FirstOrDefault(o => o.Id ==id);

    return order is not null ? Results.Ok(order) : Results.NotFound("Order not found");
});

app.MapPost("/orders", (Order newOrder) => {
    newOrder.Id = orders.Count+1;
    orders.Add(newOrder);
    return Results.Created($"/orders/{newOrder.Id}", newOrder);
});

app.MapDelete("/orders/{id}" , (int id) => {
    var order = orders.FirstOrDefault(o => o.Id ==id);
    if (order is null) {
        return Results.NotFound("Order not found");
    }
    orders.Remove(order);
    return Results.Ok("Order sucessfully removed.");
});

app.Run();

