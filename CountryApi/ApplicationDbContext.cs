using CountryApi.Entities.City;
using CountryApi.Entities.Country;
using Microsoft.EntityFrameworkCore;

namespace CountryApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
    }
}
