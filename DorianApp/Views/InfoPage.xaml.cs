using Microsoft.Maui.Controls;
using DorianApp.Services;
using System.Threading.Tasks;
using DorianApp.Models;
using System.Collections.ObjectModel;

namespace DorianApp.Views
{
    public partial class InfoPage : ContentPage
    {
        private readonly TrefleApiService _trefleApiService;
        public ObservableCollection<Plant> Plants { get; set; }

        public InfoPage()
        {
            InitializeComponent();
            _trefleApiService = new TrefleApiService();
            Plants = new ObservableCollection<Plant>();
            BindingContext = this;
            LoadPlants();
        }

        private async void LoadPlants()
        {
            var plants = await _trefleApiService.GetPlantsAsync();
            foreach (var plant in plants)
            {
                Plants.Add(plant);
            }
        }

        private async void OnPlantSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Plant selectedPlant)
            {
                await Navigation.PushAsync(new PlantDetailPage(selectedPlant));
                plantsCollectionView.SelectedItem = null;
            }
        }
    }
}