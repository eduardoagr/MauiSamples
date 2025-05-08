namespace FireChat;

public partial class AppShell : Shell {

    readonly WeakReferenceMessenger _messenger;

    public AppShell(AppShellViewModel appShellViewModel, WeakReferenceMessenger messenger) {

        InitializeComponent();

        BindingContext = appShellViewModel;
        _messenger = messenger;

        messenger.Register<string>(this, (recipient, message) => {
            switch(message) {
                case "OpenProfile":
                    UserProfilePopup.IsOpen = true;
                    break;
                case "SavePopUpContent":
                    UserProfilePopup.IsOpen = false;
                    break;
                default:
                    break;
            }
        });
    }
}
