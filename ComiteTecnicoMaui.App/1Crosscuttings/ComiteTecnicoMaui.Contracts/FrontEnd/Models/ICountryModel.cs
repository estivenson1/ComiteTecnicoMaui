using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.FrontEnd.Models;

namespace ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.FrontEnd;

    public interface ICountryModel
    {
      Task<List<Country>> GetCountriesAsync();
    }

