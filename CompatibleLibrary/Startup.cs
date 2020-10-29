using CompatibleLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CompatibleLibrary
{
    public static class Startup
    {
        public static void AddCountriesClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient<ICountriesServiceClient, CountriesServiceClient>(c =>
            {
                c.BaseAddress = new Uri("https://restcountries.eu");
            });
        }
    }
}
