using ComiteTecnicoMaui.App.Customs;


using ComiteTecnicoMaui.App._1.Proxy.ServiceClients;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.FrontEnd;
using ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Contracts.ServiceClients;
using ComiteTecnicoMaui.App.Models;
using ComiteTecnicoMaui.App.ViewModels;
using ComiteTecnicoMaui.App.ViewModels.PopUps;
using ComiteTecnicoMaui.App.Views;
using ComiteTecnicoMaui.App.Views.PopUps;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;


//#if ANDROID
//using ComiteTecnicoMaui.App.Platforms.Android.Handlers;
//#endif



namespace ComiteTecnicoMaui.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder
                .RegisterProxies()
                .RegisterModels()
                .RegisterViewsAndViewModels()
                .ConfigureMauiHandlers(handlers =>
                {
#if __ANDROID__
                    handlers.AddHandler(typeof(CustomPicker), typeof(CustomPickerHandler));
#endif
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterProxies(this MauiAppBuilder mauiAppBuilder)
        {           
            mauiAppBuilder.Services.AddTransient<ICountryServiceClient, CountryServiceClient>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ICountryModel, CountryModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<CountriesView>(); 
            mauiAppBuilder.Services.AddSingleton<CountriesViewModel>(); 

            //mauiAppBuilder.Services.AddTransientWithShellRoute<SelectOptionIdimeView, SelectOptionIdimeViewModel>(nameof(SelectOptionIdimeView));  

            //PopUp 
            mauiAppBuilder.Services.AddTransientPopup<GeneralPopUpView, GeneralPopUpViewModel>();

            return mauiAppBuilder;
        }
    }
}
