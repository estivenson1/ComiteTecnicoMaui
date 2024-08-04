using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.FrontEnd.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ComiteTecnicoMaui.App.ViewModels;

public partial class ViewModelBase : ObservableObject, IViewModelBase
{
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
            {
                ((App)Application.Current).IsBusy = value;
            }
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}

//Para llama al ViewModel sin pasar por el constructor
// var _popupService = App.Current.Handler.MauiContext.Services.GetService<IPopupService>();


#region Attributes *****************************************************

#endregion

#region Properties *****************************************************
//[ObservableProperty] string flasXX;
#endregion

#region Constructor  ***************************************************
//public XXXXXXXXXXXXX(INavigationService navigationService) : base(navigationService)
//{
//}
#endregion

#region RelayCommand  **************************************************
//[RelayCommand]
//private void YYYY()
//{
//    string zx = string.Empty;
//}

//[RelayCommand]
//private async Task YYYYAsync()
//{
//    await IsBusyFor(
//      async () =>
//      {
//          try
//          {
//              await Task.Delay(10);
//          }
//          catch (Exception ex)
//          {
//              string message = ex.Message;
//              return;
//          }
//      });
//}

//[RelayCommand(CanExecute = nameof(IsBusy))]
//private async Task XXXX()
//{
//    await Task.Delay(10);
//}
#endregion

#region Methods  *******************************************************
#endregion

#region Navigating Override Methods ************************************
//public override void ApplyQueryAttributes(IDictionary<string, object> parameters)
//{
//    base.ApplyQueryAttributes(parameters);
//}
#endregion

