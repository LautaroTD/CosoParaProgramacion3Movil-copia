﻿using Microsoft.Extensions.Logging;
using CosoParaProgramacion3Movil.Models;

namespace CosoParaProgramacion3Movil
{
    public static class MauiProgram
    {
        //public static MauiApp App { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSingleton<Services.UsuarioService>(); //esto es lo que fallaba, es Singleton, lo que significa que todo vuelve a la normalidad una vez se mata el programa, eso no pasara cuando usemos base de datos.
            builder.Services.AddSingleton<Services.PlantaService>(); //cchat gpt siempre se confunde y se olvida agregar el Services antes del servicio
            builder.Services.AddSingleton<Services.SesionService>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("http://192.168.1.101:5005/") //192.168.1.100 (creo que cambia cada tanto) en casa. //10.13.238.218 con datos del celular
    }); //ACORDATE DEL PREFIJO HTTP:// NO SEAS PELOTUDO //a veces cambia, el de tu casa cambia de ese a 192.168.1.101

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
