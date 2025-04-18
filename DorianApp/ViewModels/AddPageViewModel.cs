using System.ComponentModel;
using System.Windows.Input;
using DorianApp.Models;
using DorianApp.Services;

namespace DorianApp.ViewModels
{
    public class AddPageViewModel : INotifyPropertyChanged
    {
        private string _commonName;
        private string _imageUrl;
        private string _description;
        private string _scientificName;

        public string CommonName
        {
            get => _commonName;
            set { _commonName = value; OnPropertyChanged(nameof(CommonName)); }
        }

        public string ImageUrl
        {
            get => _imageUrl;
            set { _imageUrl = value; OnPropertyChanged(nameof(ImageUrl)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public string ScientificName
        {
            get => _scientificName;
            set { _scientificName = value; OnPropertyChanged(nameof(ScientificName)); }
        }

        public ICommand AddPlantCommand { get; }
        public ICommand CancelCommand { get; }

        public AddPageViewModel()
        {
            AddPlantCommand = new Command(async () =>
            {
                var newPlant = new Plant
                {
                    CommonName = CommonName ?? "Plante sans nom",
                    ImageUrl = ImageUrl ?? "",
                    Description = Description ?? "Pas de description",
                    ScientificName = ScientificName ?? "Nom scientifique inconnu"
                };

                PlantDataStore.AddPlant(newPlant);

                MessagingCenter.Send(this, "PlantAdded", newPlant);

                await Application.Current.MainPage.DisplayAlert("Confirmation", $"Plante ajoutée : {newPlant.CommonName}", "OK");

                await Shell.Current.GoToAsync("//InfoPage");
            });

            CancelCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//InfoPage");
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}