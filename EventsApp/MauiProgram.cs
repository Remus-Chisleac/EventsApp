using EventsApp.Logic.Managers;
using Microsoft.Extensions.Logging;

namespace EventsApp
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
                    // Add BAHNSCHRIFT.TTF to the fonts collection
                    fonts.AddFont("BAHNSCHRIFT.TTF", "Bahnschrift");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //ManagersInitializer.Initialize(); <------ Comentezi linia asta
            return builder.Build();
        }
    }
}
