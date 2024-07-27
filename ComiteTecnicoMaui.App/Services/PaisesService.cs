using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Threading.Tasks;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.ComiteTecnicoMaui.Entities.BackEnd.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComiteTecnicoMaui.App.Services;

public class PaisesService
{
    public async Task ObtenerPaisesAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray paises = JArray.Parse(responseBody);

            foreach (var pais in paises)
            {
                string nombre = pais["name"]["common"].ToString();
                string capital = pais["capital"]?.FirstOrDefault()?.ToString();
                string region = pais["region"].ToString();
                string subregion = pais["subregion"].ToString();
                string poblacion = pais["population"].ToString();
                string idioma = pais["languages"]?.First?.ToString();
                string moneda = pais["currencies"]?.First?.ToString();
                string codigoISO = pais["cca2"].ToString();
                string bandera = pais["flags"]["png"].ToString();

                // Aquí puedes procesar la información como desees
            }
        }
    }

    public async Task<List<CountryResponse>> ObtenerPaises2Async()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<CountryResponse> paises = JsonConvert.DeserializeObject<List<CountryResponse>>(responseBody);
            return paises;
        }
    }
}

