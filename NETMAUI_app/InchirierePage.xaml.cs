using Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models;
namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI;

public partial class InchirierePage : ContentPage
{
    public int MasinaID { get; set; }
    public InchirierePage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetInchirieriByMasinaAsync(MasinaID);
    }

    async void OnAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InchiriereEntryPage
        {
            BindingContext = new Inchiriere
            {
                MasinaID = this.MasinaID,
                DataPreluare = DateTime.Now,
                DataReturnare = DateTime.Now.AddDays(1)
            }
        });
    }

    async void OnEditClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var inchiriereSelectata = (Inchiriere)button.CommandParameter;

        await Navigation.PushAsync(new InchiriereEntryPage
        {
            BindingContext = inchiriereSelectata
        });
    }
}