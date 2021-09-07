using AutoMapper;
using CountryApi.Dtos.City;
using CountryApi.Dtos.Country;
using CountryApi.Entities.City;
using CountryApi.Entities.Country;

namespace CountryApi.Mappings
{
    public class CountriesMapping : Profile
    {
        public CountriesMapping()
        {
            // Sourse -> Target
            CreateMap<CountryDto, CountryEntity>();
            CreateMap<CityDto, CityEntity>();
            CreateMap<CountryUpdateDto, CountryEntity>();
        }
    }
}
