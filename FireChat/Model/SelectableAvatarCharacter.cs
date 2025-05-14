namespace FireChat.Model;

public partial class SelectableAvatarCharacter : ObservableObject {

    [ObservableProperty]
    public partial AvatarCharacter AvatarCharacter { get; set; }

    [ObservableProperty]
    public partial bool IsSelected { get; set; } = false;
}
