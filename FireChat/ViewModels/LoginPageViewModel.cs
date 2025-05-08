namespace FireChat.ViewModels;

public partial class LoginPageViewModel : BaseViewModel {

    private readonly FirebaseAuthClient _authClient;
    private readonly WeakReferenceMessenger _messenger;
    private readonly FirestoreService _firestoreService;

    [ObservableProperty]
    LocalUser _localUser = new();

    public LoginPageViewModel(FirebaseAuthClient authClient, WeakReferenceMessenger messenger,
        FirestoreService firestoreService) {

        _messenger = messenger;
        _authClient = authClient;
        _firestoreService = firestoreService;

        ChechSingIn(authClient);

    }

    private static async void ChechSingIn(FirebaseAuthClient authClient) {

        await Task.Delay(1000);

        if(authClient.User != null) {
            await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
        }
    }

    [RelayCommand]
    async Task Login() {

        await _authClient.SignInWithEmailAndPasswordAsync(LocalUser.Email, LocalUser.Password);

        await _firestoreService.CreateUserAsync(LocalUser, _authClient.User.Uid);

        await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
    }

    [RelayCommand]
    void Register() {
        _messenger.Send("OpenPopUp");

    }

    // Popup Commands
    [RelayCommand]
    void ClosePopUp() {
        _messenger.Send("ClosePopUp");
    }

    [RelayCommand]
    async Task SignUp() {

        await _authClient.CreateUserWithEmailAndPasswordAsync(
            LocalUser.Email,
            LocalUser.Password,
            LocalUser.Username);

        _messenger.Send("ClosePopUp");

        await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
    }
}
