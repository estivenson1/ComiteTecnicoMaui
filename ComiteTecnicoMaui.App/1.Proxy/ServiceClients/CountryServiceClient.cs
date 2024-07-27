using ComiteTecnicoMaui.App._1.Proxy.Referentials;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.ServiceClients;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.ComiteTecnicoMaui.Entities.BackEnd.Referentials;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.ComiteTecnicoMaui.Entities.BackEnd.Responses;
using Newtonsoft.Json.Linq;

namespace ComiteTecnicoMaui.App._1.Proxy.ServiceClients;

public class CountryServiceClient : ServiceClientBase<List<JArray>>, ICountryServiceClient
{
    public async Task<ResponseBack<List<JArray>>> GetCountriesAsync()
    { 
        return await GetJArray();
    }

    //public async Task<ResponseBack<List<CountryResponse>>> GetCountriesAsync()
    //{      
    //    return null; //await Get();
    //}
}

