using CompatibleLibrary.Interfaces;
using CompatibleLibrary.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Logging;

namespace CompatibleLibrary
{
    public class CountriesServiceClient : ICountriesServiceClient
    {
        private readonly HttpClient _countriesHttpClient;
        private readonly ILogger<CountriesServiceClient> _logger;
        public CountriesServiceClient(HttpClient countriesHttpClient, ILogger<CountriesServiceClient> logger)
        {
            _countriesHttpClient = countriesHttpClient;
            _logger = logger;
        }

        public async Task<Country[]> GetCountries(string name)
        {
            try
            {
                var responseMessage = await _countriesHttpClient.GetAsync($"/rest/v2/name/{name}");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var stringContent = await responseMessage.Content.ReadAsStringAsync();
                    var content = JsonConvert.DeserializeObject<Country[]>(stringContent);

                    return content;
                }
                else
                {
                    var errorContent = await responseMessage.Content.ReadAsStringAsync();
                    _logger.LogError(errorContent);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in GetCountries", ex);
            }

            return null;
        }
    }
}
