﻿namespace SampleApiBackend.Models.Dtos
{
    public class SoapListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ScentType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }

    }
}