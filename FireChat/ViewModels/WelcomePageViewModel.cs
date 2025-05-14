namespace FireChat.ViewModels;

public partial class WelcomePageViewModel(FirebaseAuthClient firebaseAuth) : ObservableObject {

    [RelayCommand]
    async Task CheckAuth() {
        if(firebaseAuth.User != null) {
            await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
        }
        else {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
