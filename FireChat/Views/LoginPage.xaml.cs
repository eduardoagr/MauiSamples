namespace FireChat.Views;

public partial class LoginPage : ContentPage {

    readonly RegisterPopUp _registerPopUp;

    public LoginPage(LoginPageViewModel loginPageViewModel, RegisterPopUp registerPopUp,
        WeakReferenceMessenger messenger) {

        InitializeComponent();

        BindingContext = loginPageViewModel;

        _registerPopUp = registerPopUp;

        messenger.Register<string>(this, (recipient, message) => {
            switch(message) {
                case "OpenPopUp":
                    _registerPopUp.IsOpen = true;
                    break;
                case "ClosePopUp":
                    _registerPopUp.IsOpen = false;
                    break;
            }
        });
    }
}