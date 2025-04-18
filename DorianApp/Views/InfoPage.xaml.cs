using DorianApp.ViewModels;

namespace DorianApp.Views
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
            BindingContext = new InfoPageViewModel();
        }
    }
}