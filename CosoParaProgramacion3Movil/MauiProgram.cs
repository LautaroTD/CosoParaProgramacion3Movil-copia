using Microsoft.Extensions.Logging;
using CosoParaProgramacion3Movil.Models;
using CosoParaProgramacion3Movil.Services;

namespace CosoParaProgramacion3Movil
{
    public static class MauiProgram
    {
        //public static MauiApp App { get; private set; }
        //aprendizaje: Si da errores silenciosos en lineas de http, probablemente la ruta este mal. Principalmente la parte "http://10.0.2.2:5005/" y similar.
        
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
            builder.Services.AddScoped<AuthService>(); //cchat gpt siempre se confunde y se olvida agregar el Services antes del servicio
            builder.Services.AddSingleton<Services.PlantaService>();
            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddScoped(sp => new HttpClient(new HttpClientHandler
            {
                UseCookies = true,
                AllowAutoRedirect = false
            })
            {  //192.168.1.100 (creo que cambia cada tanto) en casa. //10.13.238.218 con datos del celular
                BaseAddress = new Uri("http://programacion3movilcrudapi.tryasp.net/"), // o la URL de tu API //ACORDATE DEL PREFIJO HTTP:// NO SEAS PELOTUDO //a veces cambia, el de tu casa cambia de ese a 192.168.1.101
                DefaultRequestHeaders = //NOTA CLAVE. USA http://10.0.2.2:5005/ CUANDO EJECUTES POR EMULADOR.
    {
        { "Accept", "application/json" }
    }
            });


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
