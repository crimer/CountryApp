using System.Collections.Generic;
using System.Threading.Tasks;
using CountryApi.Entities.Country;
using Microsoft.EntityFrameworkCore;

namespace CountryApi.Repositories.Country
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(CountryEntity country)
        {
            await _context.Countries.AddAsync(country);
        }

        public async Task<int> Count()
        {
            return await _context.Countries.CountAsync();
        }

        public async Task Delete(CountryEntity country)
        {
            _context.Countries.Remove(country);
        }

        public async Task<IEnumerable<CountryEntity>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<CountryEntity> GetCountryById(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task Update(CountryEntity newCountry)
        {
            // nothing
        }
    }
}
