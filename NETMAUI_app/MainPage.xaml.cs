using Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models;
using System.Collections.ObjectModel;

namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMasiniAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MasinaEntryPage
            {
                BindingContext = new Masina()
            });
        }


        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Masina selectedMasina)
            {
                await Navigation.PushAsync(new MasinaEntryPage
                {
                    BindingContext = selectedMasina
                });
                ((CollectionView)sender).SelectedItem = null;
            }
        }
        async void OnVeziInchirieriClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var masinaSelectata = (Masina)button.CommandParameter;
            var inchirierePage = new InchirierePage();
            inchirierePage.MasinaID = masinaSelectata.ID;
            inchirierePage.Title = $"Inchirieri - {masinaSelectata.Marca} {masinaSelectata.Model}";

            await Navigation.PushAsync(inchirierePage);
        }
    }
}
