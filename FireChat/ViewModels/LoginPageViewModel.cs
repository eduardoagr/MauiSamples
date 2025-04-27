namespace FireChat.ViewModels;

public partial class LoginPageViewModel : BaseViewModel {

    public required Action openPopUp;
    public required Action closePopUp;

    private FirebaseAuthClient _authClient;

    public LoginPageViewModel(FirebaseAuthClient authClient) {
        _authClient = authClient;

        if(authClient.User != null) {
            Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
    }

    [ObservableProperty]
    LocalUser _localUser = new();


    [RelayCommand]
    async Task Login() {

        await _authClient.SignInWithEmailAndPasswordAsync(LocalUser.Email, LocalUser.Password);

        await Shell.Current.GoToAsync($"{nameof(MainPage)}");
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

        await Shell.Current.GoToAsync($"{nameof(MainPage)}");
    }

}
