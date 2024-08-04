using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.FrontEnd;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.FrontEnd.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ComiteTecnicoMaui.App.ViewModels;

public partial class CountriesViewModel : ViewModelBase
{
    readonly ICountryModel _countryModel;

    [ObservableProperty] ObservableCollection<Country> countryList;

    public CountriesViewModel(ICountryModel countryModel)
    {
        _countryModel = countryModel;
    }

    public override async Task InitializeAsync()
    {
        IsBusy = true;
        var resoonse = await _countryModel.GetCountriesAsync();
        CountryList = new ObservableCollection<Country>(resoonse);
        IsBusy = false;
    }

}

