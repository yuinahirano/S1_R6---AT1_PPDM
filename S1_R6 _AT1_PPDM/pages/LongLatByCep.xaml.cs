namespace S1_R6__AT1_PPDM.pages;

public partial class LongLatByCep : ContentPage
{
	public LongLatByCep(double latitude, double longitude)
	{
		InitializeComponent();

		Latitude.Text = latitude.ToString();
		Longitude.Text = longitude.ToString();
	}
}