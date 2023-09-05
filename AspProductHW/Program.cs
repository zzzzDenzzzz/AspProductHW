using AspProductHW.Models;
using static AspProductHW.Models.SeedData.SeedData;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Products);

// RPC "/addProduct", (Product product) =>
app.MapPost("/add", (Product product) =>
{
    Products.Add(product);
    return Results.Created("/", Products);
});

app.MapPost("/add/product/{id}/{name}/{brand}/{price}", (int id, string name, string brand, decimal price) =>
{
    var product = new Product() { Id = id, Name = name, Brand = brand, Price = price};
    Products.Add(product);
    return Results.Created("/", Products);
});

// RPC "/getProductByName", (string name) => Products.FindAll(p => p.Name == name));
app.MapGet("/get/name/{name}", (string name) => Products.FindAll(p => p.Name == name));
// RPC "/getProductById", (int id) => Products.Find(p => p.Id == id));
app.MapGet("/get/id/{id}", (int id) => Products.Find(p => p.Id == id));

//RPC "/deleteProductById", (int id) =>
app.MapDelete("/delete/id/{id}", (int id) =>
{
    var product = Products.Where(p => p.Id == id).FirstOrDefault();

    if (product is null) return Results.NotFound();

    Products.Remove(product);
    return Results.NoContent();
});
// RPC "/deleteAll"
app.MapDelete("/delete", () => Products.Clear());

// RPC "/updateProductByID", (int id, Product newProduct) =>
app.MapPut("/update/id/{id}", (int id, Product newProduct) =>
{
    var product = Products.Where(p => p.Id == id).FirstOrDefault();

    if (product is null) return Results.NotFound();

    product.Id = newProduct.Id;
    product.Name = newProduct.Name;
    product.Brand = newProduct.Brand;
    product.Price = newProduct.Price;

    return Results.NoContent();
});

app.Run();