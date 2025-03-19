var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte ao Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita o Swagger na aplicação
app.UseSwagger();
app.UseSwaggerUI();

List<Order> orders = new()
{
    new Order { Id = 1, Customer = "John", Amount = 150.00m },
    new Order { Id = 2, Customer = "Mary", Amount = 200.50m }
};

//  Endpoint to get all orders
app.MapGet("/orders", () => orders);

//  Endpoint to get a specific order by ID
app.MapGet("/orders/{id}", (int id) =>
{
    var order = orders.FirstOrDefault(o => o.Id == id);
    return order is not null ? Results.Ok(order) : Results.NotFound("Order not found.");
});

//  Endpoint to add a new order
app.MapPost("/orders", (Order newOrder) =>
{
    newOrder.Id = orders.Count + 1; // Simulating a unique ID
    orders.Add(newOrder);
    return Results.Created($"/orders/{newOrder.Id}", newOrder);
});

//  Endpoint to delete an order
app.MapDelete("/orders/{id}", (int id) =>
{
    var order = orders.FirstOrDefault(o => o.Id == id);
    if (order is null) return Results.NotFound("Order not found.");
    
    orders.Remove(order);
    return Results.Ok("Order successfully removed.");
});

app.Run();