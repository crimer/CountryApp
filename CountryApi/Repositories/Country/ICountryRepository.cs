using System.Collections.Generic;
using System.Threading.Tasks;
using CountryApi.Entities.Country;

namespace CountryApi.Repositories.Country
{
    public interface ICountryRepository
    {
        Task<CountryEntity> GetCountryById(int id);
        Task Add(CountryEntity country);
        Task Delete(CountryEntity country);
        Task Update(CountryEntity newCountry);
        Task<IEnumerable<CountryEntity>> GetAll();
        Task<int> Count();
        Task<bool> Save();
    }
}
