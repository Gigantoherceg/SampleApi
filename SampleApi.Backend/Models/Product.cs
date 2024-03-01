namespace SampleApiBackend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ScentType Scent { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
    }
}
