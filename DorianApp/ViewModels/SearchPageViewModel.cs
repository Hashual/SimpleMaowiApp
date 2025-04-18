using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DorianApp.Models;
using DorianApp.Services;
using DorianApp.Views;

namespace DorianApp.ViewModels
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {
        private readonly TrefleApiService _trefleApiService;
        private List<Plant> _allPlants;
        private ObservableCollection<Plant> _filteredPlants;
        private Plant _selectedPlant;
        private bool _isPlantVisible;
        private string _searchQuery;

        public ObservableCollection<Plant> FilteredPlants
        {
            get => _filteredPlants;
            set
            {
                _filteredPlants = value;
                OnPropertyChanged(nameof(FilteredPlants));
            }
        }

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

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                SearchPlants(); // Recherche automatique à chaque changement
            }
        }

        public ICommand ShowRandomPlantCommand { get; }
        public ICommand NavigateToDetailsCommand { get; }

        public SearchPageViewModel()
        {
            _trefleApiService = new TrefleApiService();
            _allPlants = new List<Plant>();
            FilteredPlants = new ObservableCollection<Plant>();
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

            NavigateToDetailsCommand = new Command<Plant>(async (plant) =>
            {
                if (plant != null)
                {
                    await Shell.Current.Navigation.PushAsync(new PlantDetailPage(plant));
                }
            });

            // S'abonner au message "PlantAdded"
            MessagingCenter.Subscribe<AddPageViewModel, Plant>(this, "PlantAdded", (sender, newPlant) =>
            {
                _allPlants.Add(newPlant);
                SearchPlants(); // Rafraîchir les résultats de la recherche si nécessaire
            });

            LoadPlantsAsync();
        }

        public void SearchPlants()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredPlants.Clear();
                return;
            }

            var query = SearchQuery.ToLower();
            var filtered = _allPlants
                .Where(p => p.CommonName.ToLower().Contains(query) || p.ScientificName.ToLower().Contains(query))
                .ToList();

            FilteredPlants.Clear();
            foreach (var plant in filtered)
            {
                FilteredPlants.Add(plant);
            }
        }

        private async void LoadPlantsAsync()
        {
            // Charger les plantes depuis l'API
            var apiPlants = await _trefleApiService.GetPlantsAsync();
            _allPlants.AddRange(apiPlants);

            // Charger les plantes ajoutées par l'utilisateur
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