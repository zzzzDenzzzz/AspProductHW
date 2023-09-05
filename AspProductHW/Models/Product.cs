namespace AspProductHW.Models
{
    public record Product
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Brand { get; set; }

        public required decimal Price { get; set; }
    }
}
