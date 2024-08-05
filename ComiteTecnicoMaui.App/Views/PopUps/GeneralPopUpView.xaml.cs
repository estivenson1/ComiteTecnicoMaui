using ComiteTecnicoMaui.App.ViewModels.PopUps;
using CommunityToolkit.Maui.Views;

namespace ComiteTecnicoMaui.App.Views.PopUps;

public partial class GeneralPopUpView : Popup
{
    public GeneralPopUpView()
    {
        InitializeComponent();
    }

    //public GeneralPopUpView(GeneralPopUpViewModel viewModel)
    //{
    //    InitializeComponent();
    //    BindingContext = viewModel;
    //}

    private async void HideKeyBoard_Clicked(object sender, EventArgs e)
    {
        //await CloseAsync();

      await MyEditor.HideSoftInputAsync(default);
    }

    private void HabilitarMyEditor_Clicked(object sender, EventArgs e)
    {
        MyEditor.IsEnabled = true;
    }
}