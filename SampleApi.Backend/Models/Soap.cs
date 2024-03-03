namespace SampleApiBackend.Models
{
    public class Soap
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ScentType ScentType { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } = 0;

        //TODO: Add pictures
        //public byte[] Picture { get; set; }
    }
}
