using FireChat.Model;

namespace FireChat.ViewModels;

public partial class LoginPageViewModel(FirebaseAuthClient _authClient) : ObservableObject {

    public required Action openPopUp;
    public required Action closePopUp;

    [ObservableProperty]
    LocalUser _localUser = new();

    [RelayCommand]
    async Task Login() {

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

    }

    [RelayCommand]
    async Task Register() {
        openPopUp.Invoke();

    }

    // Popup Commands
    [RelayCommand]
    void ClosePopUp() {
        closePopUp.Invoke();
    }

    [RelayCommand]
    async Task SignUp() {

        await _authClient.CreateUserWithEmailAndPasswordAsync(
            LocalUser.Email,
            LocalUser.Password,
            LocalUser.Username);

        closePopUp.Invoke();

        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }

}
