using System.Collections.Generic;
using System.Threading.Tasks;
using CompatibleLibrary.Interfaces;
using CompatibleLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplicationNetCore3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {

        private readonly ILogger<CountriesController> _logger;
        private readonly ICountriesServiceClient _countriesServiceClient;

        public CountriesController(ILogger<CountriesController> logger, ICountriesServiceClient countriesServiceClient)
        {
            _logger = logger;
            _countriesServiceClient = countriesServiceClient;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> Get(string name = "romania")
        {
            return await _countriesServiceClient.GetCountries(name);
        }
    }
}
