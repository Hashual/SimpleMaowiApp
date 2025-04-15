using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DorianApp.ViewModels;

public class GifPageViewModel : INotifyPropertyChanged
{
    private bool _isBackButtonVisible;

    public bool IsBackButtonVisible
    {
        get => _isBackButtonVisible;
        set
        {
            _isBackButtonVisible = value;
            OnPropertyChanged();
        }
    }

    public ICommand BackCommand { get; }

    public GifPageViewModel()
    {
        IsBackButtonVisible = false;
        BackCommand = new Command(async () =>
        {
            await Shell.Current.GoToAsync("//HomePage");
        });

        // Simuler le délai pour afficher le bouton
        ShowBackButtonAfterDelay();
    }

    private async void ShowBackButtonAfterDelay()
    {
        await Task.Delay(2000);
        IsBackButtonVisible = true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}