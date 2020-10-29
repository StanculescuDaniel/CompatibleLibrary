using CompatibleLibrary.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplicationNetFram48.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountriesServiceClient _countriesServiceClient;
        public CountriesController(ICountriesServiceClient countriesServiceClient)
        {
            _countriesServiceClient = countriesServiceClient;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string name = "romania")
        {
            var countries =  await _countriesServiceClient.GetCountries(name);
            return Ok(countries);
        }

    }
}
