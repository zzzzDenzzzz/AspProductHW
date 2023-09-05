// See https://aka.ms/new-console-template for more information
using AspProductHW.Models.SeedData;

Console.WriteLine(SeedData.Products.Find(p => p.Price == 80.99m).Name);
