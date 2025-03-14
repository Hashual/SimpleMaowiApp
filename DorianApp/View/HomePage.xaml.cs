using DorianApp.View;

namespace DorianApp;
public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GifPage());
        
    }
}