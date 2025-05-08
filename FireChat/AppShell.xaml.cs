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

        if(sender is AvatarView avatarView) {
            avatarView.Text = Icons.MateriallFontGlyphs.Edit;
            avatarView.BackgroundColor = Colors.DarkGrey;
        }
    }

    private void AvatarImage_PointerExited(object sender, PointerEventArgs e) {

        if(sender is AvatarView avatarView) {
            avatarView.Text = Icons.MateriallFontGlyphs.Add_a_photo;
            avatarView.BackgroundColor = Colors.Transparent;
        }

    }
}
