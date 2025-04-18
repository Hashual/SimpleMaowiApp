using DorianApp.ViewModels;

namespace DorianApp.Views
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            BindingContext = new AddPageViewModel();
        }
    }
}