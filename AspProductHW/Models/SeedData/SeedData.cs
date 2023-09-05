namespace AspProductHW.Models.SeedData
{
    public static class SeedData
    {
        public static List<Product> Products { get; set; } = new()
        {
            new Product()
            {
                Id = 0,
                Name = "Milk",
                Brand = "Organic Valley",
                Price = 125m,
            },
            new Product()
            {
                Id = 1,
                Name = "Water",
                Brand = "Dasani",
                Price = 80.99m,
            },
            new Product()
            {
                Id = 2,
                Name = "Cheese",
                Brand = "Kerrygold",
                Price = 800.35m,
            },
            new Product()
            {
                Id = 3,
                Name = "Cookie",
                Brand = "MadeGood",
                Price = 222.25m,
            },
            new Product()
            {
                Id = 4,
                Name = "Milk",
                Brand = "Kerrygold",
                Price = 127.5m,
            },
        };
    }
}
