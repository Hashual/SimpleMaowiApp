using Microsoft.Maui.Controls;
using DorianApp.Models;

namespace DorianApp
{
    public partial class PlantDetailPage : ContentPage
    {
        public PlantDetailPage(Plant plant)
        {
            InitializeComponent();
            titleLabel.Text = plant.CommonName;
            plantImage.Source = plant.ImageUrl;
            descriptionLabel.Text = $"Description : {plant.Description}";
            scientificNameLabel.Text = $"Nom scientifique : {plant.ScientificName}";
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage());

        }

    }
}