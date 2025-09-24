using CosoParaProgramacion3Movil.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace CosoParaProgramacion3Movil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var blazorWebView = new BlazorWebView
            {
                HostPage = "wwwroot/index.html"
            };

            blazorWebView.RootComponents.Add(new RootComponent
            {
                Selector = "#app",
                ComponentType = typeof(Routes) // ← ¡El nuevo punto de entrada de Blazor!
            });

            Content = blazorWebView;
        }
    }
}
