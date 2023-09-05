namespace AspProductHW.Models.SeedData
{
    public static class SeedData
    {
        public static List<Product> Products { get; set; } = new()
        {
            new Product()
            {
                Name = "Milk",
                Brand = "Organic Valley",
                Price = 125m,
            },
            new Product()
            {
                Name = "Water",
                Brand = "Dasani",
                Price = 80.99m,
            },
            new Product()
            {
                Name = "Cheese",
                Brand = "Kerrygold",
                Price = 800.35m,
            },
            new Product()
            {
                Name = "Cookie",
                Brand = "MadeGood",
                Price = 222.25m,
            },
        };
    }
}
