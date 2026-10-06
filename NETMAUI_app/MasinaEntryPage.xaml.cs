using Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models;
namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI;

public partial class MasinaEntryPage : ContentPage
{
	public MasinaEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is Masina masina)
        {
            MarcaEntry.Text = masina.Marca;
            ModelEntry.Text = masina.Model;
            PretEntry.Text = masina.PretPeZi.ToString();
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var masina = (Masina)BindingContext ?? new Masina();
        masina.Marca = MarcaEntry.Text;
        masina.Model = ModelEntry.Text;
        decimal.TryParse(PretEntry.Text, out decimal pret);
        masina.PretPeZi = pret;

        await App.Database.SaveMasinaAsync(masina);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var masina = (Masina)BindingContext;
        if (masina != null && masina.ID != 0)
        {
            await App.Database.DeleteMasinaAsync(masina);
        }
        await Navigation.PopAsync();
    }
}