using Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models;
namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI;

public partial class InchiriereEntryPage : ContentPage
{
	public InchiriereEntryPage()
	{
		InitializeComponent();
	}
    async void OnSaveClicked(object sender, EventArgs e)
    {
        var inchiriere = (Inchiriere)BindingContext;

        if (string.IsNullOrWhiteSpace(inchiriere.NumeClient))
        {
            await DisplayAlert("Eroare", "Introdu numele clientului.", "OK");
            return;
        }

        if (inchiriere.DataReturnare < inchiriere.DataPreluare)
        {
            await DisplayAlert("Eroare", "Data returnarii nu poate fi inaintea preluarii!", "OK");
            return;
        }

        await App.Database.SaveInchiriereAsync(inchiriere);
        await Navigation.PopAsync();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        var inchiriere = (Inchiriere)BindingContext;
        if (inchiriere.ID != 0)
        {
            await App.Database.DeleteInchiriereAsync(inchiriere);
        }
        await Navigation.PopAsync();
    }
}