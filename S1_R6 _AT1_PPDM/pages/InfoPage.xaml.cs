namespace S1_R6__AT1_PPDM.pages;

public partial class InfoPage : ContentPage
{
	Placemark _endereco;
	public InfoPage(Placemark endereco)
	{
		InitializeComponent();
		_endereco = endereco;

		Rua.Text = _endereco.Thoroughfare;
		Numero.Text = _endereco.SubThoroughfare;
		Bairro.Text = _endereco.SubLocality;
		Cep.Text = _endereco.PostalCode;
		Cidade.Text = _endereco.SubAdminArea;
		Estado.Text = _endereco.AdminArea;

	}
}