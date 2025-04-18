using System.ComponentModel;
using System.Windows.Input;
using DorianApp.Models;
using DorianApp.Services;

namespace DorianApp.ViewModels
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {
        private readonly TrefleApiService _trefleApiService;
        private List<Plant> _allPlants;
        private Plant _selectedPlant;
        private bool _isPlantVisible;

        public Plant SelectedPlant
        {
            get => _selectedPlant;
            set
            {
                _selectedPlant = value;
                OnPropertyChanged(nameof(SelectedPlant));
            }
        }

        public bool IsPlantVisible
        {
            get => _isPlantVisible;
            set
            {
                _isPlantVisible = value;
                OnPropertyChanged(nameof(IsPlantVisible));
            }
        }

        public ICommand ShowRandomPlantCommand { get; }

        public SearchPageViewModel()
        {
            _trefleApiService = new TrefleApiService();
            _allPlants = new List<Plant>();
            IsPlantVisible = false;

            ShowRandomPlantCommand = new Command(() =>
            {
                if (_allPlants.Any())
                {
                    var random = new Random();
                    SelectedPlant = _allPlants[random.Next(_allPlants.Count)];
                    IsPlantVisible = true;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Erreur", "Aucune plante disponible.", "OK");
                }
            });

            LoadPlantsAsync();
        }

        private async void LoadPlantsAsync()
        {
            var apiPlants = await _trefleApiService.GetPlantsAsync();
            _allPlants.AddRange(apiPlants);

            var userPlants = PlantDataStore.GetPlants();
            _allPlants.AddRange(userPlants);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}