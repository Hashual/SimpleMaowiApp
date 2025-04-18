using DorianApp.ViewModels;

namespace DorianApp.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchPageViewModel();
        }
    }
}