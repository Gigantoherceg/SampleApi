using System.ComponentModel.DataAnnotations;

namespace SampleApiBackend.Models.Dtos
{
    public class CreateSoapDto
    {
        [Required(ErrorMessage ="Name is required. (From backend)")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}