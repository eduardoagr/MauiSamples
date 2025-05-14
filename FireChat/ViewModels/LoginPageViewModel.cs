namespace FireChat.ViewModels;

public partial class LoginPageViewModel(FirestoreService firestoreService,
    FirebaseAuthClient firebaseAuth) : BaseViewModel {

    [ObservableProperty]
    LocalUser _localUser = new();

    [ObservableProperty]
    bool _isRegisterPopUpVisible;

    [RelayCommand]
    async Task Login() {

        await firebaseAuth.SignInWithEmailAndPasswordAsync("admin@admin.com", "123456");

        await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");

    }

    [RelayCommand]
    void Register() {

        IsRegisterPopUpVisible = true;
    }

    // Popup Commands
    [RelayCommand]
    void ClosePopUp() {

        IsRegisterPopUpVisible = false;
    }

    [RelayCommand]
    async Task SignUp() {

        await firebaseAuth.CreateUserWithEmailAndPasswordAsync(
            LocalUser.Email,
            LocalUser.Password,
            LocalUser.Username);

        IsRegisterPopUpVisible = false;

        await firestoreService.CreateAsync(LocalUser,
            "Users",
             firebaseAuth.User.Uid);

        await Shell.Current.GoToAsync($"//{nameof(ChatPage)}");
    }
}
