//using MapKit;
using Microsoft.Maui.Devices.Sensors;
using System.Globalization;
using System.Linq;

namespace S1_R6__AT1_PPDM.pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public async Task ObterEnderecoPorCoordenada(double latitude, double longitude)
    {
        try
        {
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

            Placemark endereco = placemarks?.FirstOrDefault();

            if (endereco != null)
            {
                Navigation.PushAsync(new InfoPage(endereco));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync($"Erro", "Erro interno no servidor", "OK");
        }
    }

    public async Task ObterCoordenadasPorCep()
    {
        try
        {
            string enderecoBusca = "Av. Rebouças, 3965, Sumaré - SP";

            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(enderecoBusca);
            Location location = locations?.FirstOrDefault();

            if (location != null)
            {
                double lat = location.Latitude;
                double lng = location.Longitude;
                Navigation.PushAsync(new LongLatByCep(lat, lng));
            }

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync($"Erro", "Erro interno no servidor", "OK");
        }
    }

    private async void ButProcurar_Clicked(object sender, EventArgs e)
    {
        if (double.TryParse(TxtLatitude.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double latitude) &&
        double.TryParse(TxtLongitude.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double longitude))
        {
            await ObterEnderecoPorCoordenada(latitude, longitude);
        }
    }

    private async void ButProcurarByCep_Clicked(object sender, EventArgs e)
    {
        await ObterCoordenadasPorCep();
    }
}