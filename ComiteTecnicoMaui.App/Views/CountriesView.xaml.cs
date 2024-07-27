using ComiteTecnicoMaui.App.ViewModels;

namespace ComiteTecnicoMaui.App.Views;

public partial class CountriesView : ContentPage
{
	readonly CountriesViewModel _viewModel;
    public CountriesView(CountriesViewModel viewModel)
	{
		BindingContext = _viewModel=viewModel;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        await _viewModel.GetCountriesAsync();
    }
}