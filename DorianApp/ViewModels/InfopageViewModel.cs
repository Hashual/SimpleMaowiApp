using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DorianApp.Models;
using DorianApp.Services;
using DorianApp.Views;
using Microsoft.Maui.Controls;

namespace DorianApp.ViewModels
{
    public class InfoPageViewModel : INotifyPropertyChanged
    {
        private readonly TrefleApiService _trefleApiService;
        private ObservableCollection<Plant> _plants;

        public ObservableCollection<Plant> Plants
        {
            get => _plants;
            set
            {
                _plants = value;
                OnPropertyChanged(nameof(Plants));
            }
        }

        public ICommand PlantSelectedCommand { get; }

        public InfoPageViewModel()
        {
            _trefleApiService = new TrefleApiService();
            Plants = new ObservableCollection<Plant>();
            PlantSelectedCommand = new Command<Plant>(async (plant) =>
            {
                if (plant != null)
                {
                    await Shell.Current.Navigation.PushAsync(new PlantDetailPage(plant));
                }
            });

            LoadPlantsAsync();
        }

        private async void LoadPlantsAsync()
        {
            var plants = await _trefleApiService.GetPlantsAsync();
            foreach (var plant in plants)
            {
                Plants.Add(plant);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}