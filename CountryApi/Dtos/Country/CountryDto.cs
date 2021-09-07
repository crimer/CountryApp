using System;
using System.ComponentModel.DataAnnotations;
using CountryApi.Entities.Country;

namespace CountryApi.Dtos.Country
{
    public class CountryDto
    {
        [Required(ErrorMessage = "Имя обязательно")]
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        [Required(ErrorMessage = "Официальный язык обязателен")]
        public string OfficialLanguage { get; set; }
        [Required]
        public string Capital { get; set; }
        [Required(ErrorMessage = "Territory обязателен")]
        [Range(1, 100, ErrorMessage = "Territory должен быть в промежутке от 1 до 100")]
        public int Territory { get; set; }
        public long Population { get; set; }
        public double GdpTotal { get; set; }
        public double HDI { get; set; }
        public string Currency { get; set; }
        public CarTraffic CarTraffic { get; set; }
    }
}
