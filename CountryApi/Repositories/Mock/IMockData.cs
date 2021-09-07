using System.Threading.Tasks;

namespace CountryApi.Repositories.Mock
{
    public interface IMockData
    {
        Task Init(ApplicationDbContext dbContext);
    }
}
