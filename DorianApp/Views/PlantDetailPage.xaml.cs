using DorianApp.Models;
using DorianApp.ViewModels;

namespace DorianApp.Views
{
    public partial class PlantDetailPage : ContentPage
    {
        public PlantDetailPage(Plant plant)
        {
            InitializeComponent();
            BindingContext = new PlantDetailPageViewModel(plant);
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage());
        }
    }
}