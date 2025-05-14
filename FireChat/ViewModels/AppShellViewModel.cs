

namespace FireChat.ViewModels;

public partial class AppShellViewModel : BaseViewModel {

    readonly FirebaseAuthClient _authClient;
    readonly WeakReferenceMessenger _messenger;
    readonly IMediaPicker _mediaPicker;

    [ObservableProperty]
    public partial LocalUser LocalUser { get; set; } = new();

    [ObservableProperty]
    public partial UserAvatarOptions? SelectedItem { get; set; }

    [ObservableProperty]
    public partial AvatarCharacter SelectedAvatar { get; set; }

    public ObservableCollection<UserAvatarOptions>? OptionsColletion { get; set; } = [];

    public List<AvatarCharacter> AvatarCharacters { get; set; } =
        [.. Enum.GetValues<AvatarCharacter>()];

    public AppShellViewModel(FirebaseAuthClient authClient, WeakReferenceMessenger messenger, IMediaPicker mediaPicker) {

        _authClient = authClient;
        _messenger = messenger;
        _mediaPicker = mediaPicker;

        GetOptions();
    }


    [RelayCommand]
    async Task SignOut() {

        _authClient.SignOut();

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    [RelayCommand]
    void OpenProfile() {

        _messenger.Send("OpenProfilePopUp");

    }

    [RelayCommand]
    void SavePopUpContent() {

        _messenger.Send("SavePopUpContent");
    }

    [RelayCommand]
    void AvatarSelectionPopup() {
        _messenger.Send("OpenAvatarSeletionPopUp");
    }

    [RelayCommand]
    void SelectedOption() {

        Action action = SelectedItem?.Name switch {
            "Change avatar" => AvatarSelectionPopup,
            "Remove avatar" => RemovePicture,
            _ => () => throw new InvalidOperationException("Invalid selection."),
        };

        // Execute the selected action
        action();
    }

    [RelayCommand]
    void AvatarSelected() {

    }


    private async Task ChangePicture() {

        var NewImagePath = await _mediaPicker.PickPhotoAsync(new MediaPickerOptions() {
            Title = "Select a new profile picture"
        });

        if(NewImagePath != null) {
            LocalUser.ImagePath = NewImagePath.FullPath;

        }

    }

    private void RemovePicture() {

        LocalUser.ImagePath = string.Empty;
    }

    //private async Task TakePicture() {

    //    if(_mediaPicker.IsCaptureSupported) {

    //        var photo = await _mediaPicker.CapturePhotoAsync();

    //        if(photo != null) {

    //            string newFileName = $"{LocalUser.Username}-{DateTime.Today:yyyy-MM-dd}.jpg";
    //            string localFilePath = Path.Combine(FileSystem.CacheDirectory, newFileName);

    //            using Stream sourceStream = await photo.OpenReadAsync();
    //            using FileStream localFileStream = File.OpenWrite(localFilePath);

    //            await sourceStream.CopyToAsync(localFileStream);

    //            Debug.WriteLine($"Image saved to: {localFilePath}");
    //            LocalUser.ImagePath = localFilePath;
    //        }
    //    }
    //    else {
    //        Debug.WriteLine("Camera not supported");
    //    }
    //}

    public void GetOptions() {

        var options = new List<string> {
            "Change avatar",
            "Remove avatar"
        };

        OptionsColletion!.Clear();

        for(int i = 0; i < options.Count; i++) {
            OptionsColletion.Add(new UserAvatarOptions {

                Name = options[i],
                IsFirst = i == 0,
            });
        }
    }



}
