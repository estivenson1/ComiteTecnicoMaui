using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.ComiteTecnicoMaui.Entities.BackEnd.Referentials;
using Newtonsoft.Json.Linq;

namespace ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.ServiceClients
{
    public interface ICountryServiceClient
    {     
        Task<ResponseBack<List<JArray>>> GetCountriesAsync();
    }
}
