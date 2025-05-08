namespace FireChat.ViewModels;

public partial class AppShellViewModel : BaseViewModel {

    readonly FirebaseAuthClient _authClient;
    readonly WeakReferenceMessenger _messenger;
    readonly IMediaPicker _mediaPicker;

    [ObservableProperty]
    LocalUser localUser = new();

    [ObservableProperty]
    string? _userName;

    public AppShellViewModel(FirebaseAuthClient authClient, WeakReferenceMessenger messenger, IMediaPicker mediaPicker) {

        _authClient = authClient;

        if(_authClient.User != null) {
            _userName = _authClient.User.Info.DisplayName;
        }

        _messenger = messenger;
        _mediaPicker = mediaPicker;
    }

    [RelayCommand]
    async Task SignOut() {

        _authClient.SignOut();

        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void OpenProfile() {

        _messenger.Send("OpenProfile");

    }

    [RelayCommand]
    void SavePopUpContent() {

        _messenger.Send("SavePopUpContent");
    }

    [RelayCommand]
    async Task AvatarImageClicked() {

        await Shell.Current.DisplayActionSheet("Choose an option", "Cancel", null, "Take a photo", "Choose from gallery");
        var result = await _mediaPicker.PickPhotoAsync(new MediaPickerOptions {
            Title = "Pick a photo"
        });
        if(result != null) {
            var stream = await result.OpenReadAsync();
            LocalUser.ImagePath = stream.ToString();
        }
    }
}
