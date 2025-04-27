namespace FireChat.ViewModels;

public partial class MainViewModel : BaseViewModel {

    private FirebaseAuthClient _authClient;
    private LoginPageViewModel _loginPageViewModel;

    public MainViewModel(FirebaseAuthClient authClient, LoginPageViewModel loginPageViewModel) {
        _authClient = authClient;
        _loginPageViewModel = loginPageViewModel;
    }



    [RelayCommand]
    void signOut() {

    }
}
