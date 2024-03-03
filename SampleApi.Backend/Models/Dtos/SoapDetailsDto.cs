namespace SampleApiBackend.Models.Dtos
{
    public class SoapDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ScentType { get; set; } = string.Empty;   //enum!
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}