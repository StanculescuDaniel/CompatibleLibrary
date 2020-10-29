using CompatibleLibrary.Models;
using System.Threading.Tasks;

namespace CompatibleLibrary.Interfaces
{
    public interface ICountriesServiceClient
    {
        Task<Country[]> GetCountries(string name);
    }
}
