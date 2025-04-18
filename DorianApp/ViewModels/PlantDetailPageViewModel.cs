using System.ComponentModel;
using System.Windows.Input;
using DorianApp.Models;

namespace DorianApp.ViewModels
{
    public class PlantDetailPageViewModel : INotifyPropertyChanged
    {
        private Plant _plant;

        public string CommonName => _plant.CommonName;
        public string ImageUrl => _plant.ImageUrl;
        public string Description => $"Description : {_plant.Description}";
        public string ScientificName => $"Nom scientifique : {_plant.ScientificName}";

        public ICommand BackCommand { get; }

        public PlantDetailPageViewModel(Plant plant)
        {
            _plant = plant ?? new Plant();
            BackCommand = new Command(async () => await Shell.Current.GoToAsync("//InfoPage"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}