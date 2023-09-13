using AspProductHW.Models;
using static AspProductHW.Models.SeedData.SeedData;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Products);

// REST
app.MapPost("/product", (Product product) =>
{
    Products.Add(product);
    return Results.Created("/", Products);
});
app.MapGet("/product/name/{name}", (string name) => Products.FindAll(p => p.Name == name));
app.MapGet("/product/{id}", (int id) => Products.Find(p => p.Id == id));
app.MapDelete("/product/{id}", (int id) =>
{
    var product = Products.Where(p => p.Id == id).FirstOrDefault();

    if (product is null) return Results.NotFound();

    Products.Remove(product);
    return Results.NoContent();
});
app.MapDelete("/product", () => Products.Clear());
app.MapPut("/product/{id}", (int id, Product newProduct) =>
{
    var product = Products.Where(p => p.Id == id).FirstOrDefault();

    if (product is null) return Results.NotFound();

    product.Id = newProduct.Id;
    product.Name = newProduct.Name;
    product.Brand = newProduct.Brand;
    product.Price = newProduct.Price;

    return Results.NoContent();
});

// RPC
app.MapPost("/addProduct", (Product product) =>
{
    Products.Add(product);
    return Results.Created("/", Products);
});
app.MapGet("/getProductByName", (string name) => Products.FindAll(p => p.Name == name));
app.MapGet("/getProductById", (int id) => Products.Find(p => p.Id == id));
app.MapPost("deleteProductById", (int id) =>
{
    var product = Products.Where(p => p.Id == id).FirstOrDefault();

    if (product is null) return Results.NotFound();

    Products.Remove(product);
    return Results.NoContent();
});
app.MapPost("/deleteProducts", () => Products.Clear());
app.MapPost("/updateProductById", (int id, Product newProduct) =>
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