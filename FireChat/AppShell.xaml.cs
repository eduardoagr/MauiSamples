using CommunityToolkit.Maui.Views;

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

    private void AvatarImage_PointerEntered(object sender, PointerEventArgs e) {

        AvatarViewSetUp(Icons.MateriallFontGlyphs.Add_a_photo, Colors.DarkGray, sender);
    }

    private void AvatarImage_PointerExited(object sender, PointerEventArgs e) {

        AvatarViewSetUp(Icons.MateriallFontGlyphs.Add_a_photo, Colors.Transparent, sender);

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) {

        if(sender is AvatarView avatarView) {
            AvatarPopUp.RelativeView = avatarView; // Attach popup to AvatarView
            AvatarPopUp.IsOpen = true; // Open popup
        }

    }

    private void AvatarViewSetUp(string glyph, Color BackgroudColor, object sender) {

        if(sender is AvatarView avatarView) {
            avatarView.Text = glyph;
            avatarView.BackgroundColor = BackgroudColor;
        }

    }
}
