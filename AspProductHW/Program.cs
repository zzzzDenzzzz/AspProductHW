using AspProductHW.Models;
using static AspProductHW.Models.SeedData.SeedData;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Products);

app.MapPost("/addProduct", (Product product) =>
{
    Products.Add(product);
    return Results.Created("/", Products);
});

app.MapGet("/getProductByName", (string name) => Products.FindAll(p => p.Name == name));
app.MapGet("/getProductById", (int id) => Products.Find(p => p.Id == id));

app.MapDelete("/deleteProductById", (int id) =>
{
    var product = Products.Where(p => p.Id == id).FirstOrDefault();

    if (product is null) return Results.NotFound();

    Products.Remove(product);
    return Results.NoContent();
});
app.MapDelete("/deleteAll", () => Products.Clear());

app.MapPut("/updateProductById", (int id, Product newProduct) =>
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