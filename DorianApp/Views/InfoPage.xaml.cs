using DorianApp.ViewModels;

namespace DorianApp.Views
{
    public partial class InfoPage : ContentPage
    {
        private InfoPageViewModel _viewModel;

        public InfoPage()
        {
            InitializeComponent();
            _viewModel = new InfoPageViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.RefreshPlants();
        }
    }
}