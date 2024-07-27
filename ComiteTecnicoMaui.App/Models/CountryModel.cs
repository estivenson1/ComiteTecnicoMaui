using ComiteTecnicoMaui.App._1.Proxy.ServiceClients;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.FrontEnd;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.ServiceClients;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.FrontEnd.Models;
using Newtonsoft.Json.Linq;

namespace ComiteTecnicoMaui.App.Models;

public class CountryModel : ICountryModel
{
    readonly ICountryServiceClient _serviceClient;

    public CountryModel(ICountryServiceClient serviceClient)
    {
        _serviceClient = serviceClient;
    }
    public async Task<List<Country>> GetCountriesAsync()
    {
        var response = await _serviceClient.GetCountriesAsync();
        return GetCountriesParse(response.MyJArray);
    }

    private List<Country> GetCountriesParse(JArray countries)
    {
        var countryList = new List<Country>();

        foreach (var country in countries)
        {
            var countryInfo = new Country
            {
                Name = country["name"]["common"].ToString(),
                Capital = country["capital"]?.FirstOrDefault()?.ToString(),
                Region = country["region"].ToString(),
                Subregion = country["subregion"]?.ToString() ?? "NA",
                Population = country["population"].ToString(),
                Language = country["languages"]?.First?.ToString(),
                Currency = country["currencies"]?.First?.ToString(),
                IsoCode = country["cca2"].ToString(),
                Flag = country["flags"]["png"].ToString()
            };

            countryList.Add(countryInfo);
        }

        return countryList;
    }
}

