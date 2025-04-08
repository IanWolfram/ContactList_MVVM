using ContactList_MVVM.ViewModels;
using ContactList_MVVM.Views;
using Microsoft.Extensions.Logging;

namespace ContactList_MVVM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register services
            builder.Services.AddSingleton<ContactsViewModel>();
            builder.Services.AddTransient<AddContactViewModel>();
            builder.Services.AddTransient<ContactDetailsViewModel>();

            // Register pages
            builder.Services.AddSingleton<ContactsPage>();
            builder.Services.AddTransient<AddContactPage>();
            builder.Services.AddTransient<ContactDetailsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}