using System.ComponentModel.DataAnnotations;
using CountryApi.Dtos.Country;
using CountryApi.Entities.City;

namespace CountryApi.Dtos.City
{
    public class CityDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public CountryDto Country { get; set; }
        [Required]
        public Status Status { get; set; }
        public double Square { get; set; }
        [Required]
        public long Population { get; set; }
    }
}
