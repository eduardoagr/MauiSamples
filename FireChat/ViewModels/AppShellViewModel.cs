namespace FireChat.ViewModels;

public partial class AppShellViewModel : BaseViewModel {

    readonly FirebaseAuthClient _authClient;
    private readonly WeakReferenceMessenger _messenger;

    [ObservableProperty]
    LocalUser localUser = new();

    [ObservableProperty]
    string? _userName;

    public AppShellViewModel(FirebaseAuthClient authClient, WeakReferenceMessenger messenger) {

        _authClient = authClient;

        if(_authClient.User != null) {
            _userName = _authClient.User.Info.DisplayName;
        }

        _messenger = messenger;
    }

    [RelayCommand]
    async Task SignOut() {

        _authClient.SignOut();

        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void OpenProfile() {

        _messenger.Send("OpenProfile");

    }

    [RelayCommand]
    void SavePopUpContent() {

        _messenger.Send("SavePopUpContent");
    }
}
