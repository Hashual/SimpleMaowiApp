namespace DorianApp.View;

public partial class GifPage : ContentPage
{
    public GifPage()
    {
        InitializeComponent();
        ShowBackButtonAfterGif();
    }

    private async void ShowBackButtonAfterGif()
    {
        await Task.Delay(2000); 
        BackButton.IsVisible = true;
    }

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage());

    }
}
