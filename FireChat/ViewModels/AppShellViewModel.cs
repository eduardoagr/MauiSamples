using System.Collections.ObjectModel;

namespace FireChat.ViewModels;

public partial class AppShellViewModel : BaseViewModel {

    readonly FirebaseAuthClient _authClient;
    readonly WeakReferenceMessenger _messenger;
    readonly IMediaPicker _mediaPicker;

    [ObservableProperty]
    LocalUser localUser = new();

    [ObservableProperty]
    string? _selectedItem;

    public ObservableCollection<string>? OptionsColletion { get; set; }

    public AppShellViewModel(FirebaseAuthClient authClient, WeakReferenceMessenger messenger, IMediaPicker mediaPicker) {

        _authClient = authClient;

        if(_authClient.User != null) {
            localUser.Username = _authClient.User.Info.DisplayName;
            localUser.Email = _authClient.User.Info.Email;
        }

        _messenger = messenger;
        _mediaPicker = mediaPicker;

        OptionsColletion = GetOptions();
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
    void SelectedOption() {

        Action action = SelectedItem switch {
            "Take picture" => async () => await TakePicture(),
            "Remove picture" => RemovePicture,
            "Change picture" => async () => await ChangePicture(),
            _ => () => throw new InvalidOperationException("Invalid selection.")
        };

        // Execute the selected action
        action();

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

    private async Task TakePicture() {

        if(_mediaPicker.IsCaptureSupported) {

            var photo = await _mediaPicker.CapturePhotoAsync();

            if(photo != null) {

                string newFileName = $"{LocalUser.Username}-{DateTime.Today.ToString("yyyy-MM-dd")}.jpg";
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, newFileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                Debug.WriteLine($"Image saved to: {localFilePath}");

                LocalUser.ImagePath = new Uri(localFilePath).AbsoluteUri;

            }
        }
        else {
            Debug.WriteLine("Camera not supported");
        }
    }

    public ObservableCollection<string> GetOptions() {

        OptionsColletion = ["Take picture", "Remove picture", "Change picture"];

        return OptionsColletion;
    }

}
