namespace FireChat.Views;

public partial class LoginPage : ContentPage {

    readonly RegisterPopUp _registerPopUp;

    public LoginPage(LoginPageViewModel loginPageViewModel, RegisterPopUp registerPopUp,
        WeakReferenceMessenger messenger) {

        InitializeComponent();

        BindingContext = loginPageViewModel;

        _registerPopUp = registerPopUp;

        messenger.Register<string>(this, (recipient, message) => {

            _registerPopUp.IsOpen = message switch {
                "OpenPopUp" => true,
                "ClosePopUp" => false,
                _ => _registerPopUp.IsOpen // Preserve current state if message isn't recognized
            };
        });
    }
}