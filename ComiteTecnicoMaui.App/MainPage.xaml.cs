using ComiteTecnicoMaui.App.ViewModels.PopUps;
using ComiteTecnicoMaui.App.Views.PopUps;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace ComiteTecnicoMaui.App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnPopUpClicked(object sender, EventArgs e)
        {
            GeneralPopUpView popup=new GeneralPopUpView();  
            await Shell.Current.CurrentPage.ShowPopupAsync(popup);


            //var _popupService = App.Current.Handler.MauiContext.Services.GetService<IPopupService>();
            //await _popupService.ShowPopupAsync<GeneralPopUpViewModel>(
            //    onPresenting: viewModel =>
            //    {

            //    });
        }
    }

}
