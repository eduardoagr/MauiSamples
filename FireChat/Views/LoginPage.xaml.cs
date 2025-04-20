namespace FireChat.Views;

public partial class LoginPage : ContentPage {

    readonly RegisterPopUp _registerPopUp;

    public LoginPage(LoginPageViewModel loginPageViewModel, RegisterPopUp registerPopUp) {
        InitializeComponent();
        BindingContext = loginPageViewModel;

        _registerPopUp = registerPopUp;

        loginPageViewModel.openPopUp = () => {
            _registerPopUp.IsOpen = true;
        };

        loginPageViewModel.closePopUp = () => {
            _registerPopUp.IsOpen = false;
        };
    }
}