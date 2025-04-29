namespace FireChat.ViewModels;

public partial class MainViewModel : BaseViewModel {

    [ObservableProperty]
    string _username;

    FirebaseAuthClient _authClient;

    public MainViewModel(FirebaseAuthClient authClient) {
        _authClient = authClient;
        _username = _authClient.User.Info.DisplayName ?? "User";


    }

    [RelayCommand]
    void SignOut() {

        Shell.Current.GoToAsync("..");

    }
}
