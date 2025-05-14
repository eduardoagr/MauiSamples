namespace FireChat;

public partial class AppShell : Shell {

    readonly WeakReferenceMessenger _messenger;
    readonly AppShellViewModel _appShellViewModel;

    public AppShell(AppShellViewModel shellViewModel,
        WeakReferenceMessenger messenger) {

        _appShellViewModel = shellViewModel;
        InitializeComponent();

        BindingContext = _appShellViewModel;
        _messenger = messenger;

        messenger.Register<string>(this, (recipient, message) => {
            switch(message) {
                case "OpenProfilePopUp":
                    UserProfilePopup.IsOpen = true;
                    break;
                case "SavePopUpContent":
                    UserProfilePopup.IsOpen = false;
                    break;
                case "OpenAvatarSeletionPopUp":
                    AvatarSeletionPopUp.IsOpen = true;
                    break;
                default:
                    break;
            }
        });
    }



    private void AvatarPointerGeture_PointerEntered(object sender, PointerEventArgs e) {

        AvatarViewSetUp(Colors.DarkGrey, sender);
    }

    private void AvatarPointerGeture_PointerExited(object sender, PointerEventArgs e) {

        AvatarViewSetUp(Color.FromArgb("#6495ed"), sender);
    }

    private void AvatarTapGesture_Tapped(object sender, TappedEventArgs e) {

        if(sender is SfAvatarView avatarView) {
            AvatarOptionsPopUp.RelativeView = avatarView; // Attach popup to AvatarView
            AvatarOptionsPopUp.IsOpen = true; // Open popup
        }
    }

    private void AvatarViewSetUp(Color BackgroudColor, object sender) {

        if(sender is SfAvatarView avatarView) {
            avatarView.Background = BackgroudColor;
        }
    }

    /*    private void AvatarsBorder_Tapped(object sender, TappedEventArgs e) {

            if(sender is Border border) {
                border.BackgroundColor = Colors.Red;
            }
        }*/
}
