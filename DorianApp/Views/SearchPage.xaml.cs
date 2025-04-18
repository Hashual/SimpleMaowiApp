using DorianApp.ViewModels;

namespace DorianApp.Views
{
    public partial class SearchPage : ContentPage
    {
        private SearchPageViewModel _viewModel;

        public SearchPage()
        {
            InitializeComponent();
            _viewModel = new SearchPageViewModel();
            BindingContext = _viewModel;
        }

        private void OnSearchCompleted(object sender, EventArgs e)
        {
            _viewModel.SearchPlants();
        }
    }
}