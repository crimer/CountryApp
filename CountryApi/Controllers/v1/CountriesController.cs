using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountryApi.Dtos.City;
using CountryApi.Dtos.Country;
using CountryApi.Entities.Country;
using CountryApi.Repositories.Country;

namespace CountryApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/contries")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountriesController> _logger;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository, ILogger<CountriesController> logger, IMapper mapper)
        {
            _logger = logger;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        // GET api/countries
        [HttpGet("getAllCountries")]
        public async Task<ActionResult<IEnumerable<CountryEntity>>> GetAllCountries()
        {
            _logger.LogInformation("Log message in the GET method");
            var countries = await _countryRepository.GetAll();
            return Ok(countries);
        }
 
        // GET api/countries/:id
        [HttpGet("{id:int}", Name = "getById")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CountryEntity>(country.Result));
        }

        // POST api/country
        [HttpPost("addCountry")]
        public async Task<IActionResult> AddCountry([FromBody] CountryDto countryDto)
        {
            try
            {
                if (countryDto == null)
                    return BadRequest();
                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var countryModel = _mapper.Map<CountryEntity>(countryDto);
                
                await _countryRepository.Add(countryModel);
                await _countryRepository.Save();
                return Ok(countryModel);
            }
            catch (Exception e)
            {
                _logger.LogError($"Во время добавления страны произошла ошибка: {e.Message}");
                return StatusCode(500, new { error = "Error in saving new Country" });
            }
        }

        // PUT api/countries/:id
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryUpdateDto update)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            _mapper.Map(update, country);
            await _countryRepository.Update(country);
            await _countryRepository.Save();
            return Ok(country);
        }

        // DELETE api/countries/:id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if(country == null)
            {
                return NotFound();
            }
            await _countryRepository.Delete(country);
            await _countryRepository.Save();
            return Ok();
        }
    }
}