namespace FireChat.ViewModels;

public partial class WelcomePageViewModel : ObservableObject {


    [RelayCommand]
    async Task CheckAuth() {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

}
