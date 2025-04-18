using DorianApp.Views;

namespace DorianApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("GifPage", typeof(GifPage));
        }
    }
}