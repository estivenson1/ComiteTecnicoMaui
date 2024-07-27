using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.FrontEnd;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.FrontEnd.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ComiteTecnicoMaui.App.ViewModels;

public partial class CountriesViewModel : ObservableObject
{
    readonly ICountryModel _countryModel;

    [ObservableProperty] ObservableCollection<Country> countryList;

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public CountriesViewModel(ICountryModel countryModel)
    {
        _countryModel = countryModel;
    }
    public async Task GetCountriesAsync()
    {
        IsBusy=true;
        var resoonse = await _countryModel.GetCountriesAsync();
        CountryList = new ObservableCollection<Country>(resoonse);
        IsBusy=false;   
    }
}

