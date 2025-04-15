using System.Windows.Input;
using DorianApp.Views;

namespace DorianApp.ViewModels;

public class HomePageViewModel
{
    public ICommand NavigateToGifCommand { get; }

    public HomePageViewModel()
    {
        NavigateToGifCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync(nameof(GifPage));
        });
    }
}