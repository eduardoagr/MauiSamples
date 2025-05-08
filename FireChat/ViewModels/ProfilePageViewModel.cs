namespace FireChat.ViewModels {

    public partial class ProfilePageViewModel : ObservableObject {

        readonly FirestoreService _firestoreService;
        readonly FirebaseAuthClient _authClient;
        readonly IMediaPicker _mediaPicker;

        [ObservableProperty]
        LocalUser _user = new();

        public ProfilePageViewModel(FirestoreService firestoreService,
            FirebaseAuthClient authClient,
            IMediaPicker mediaPicker) {

            _firestoreService = firestoreService;
            _authClient = authClient;
            _mediaPicker = mediaPicker;

            User.Username = _authClient.User.Info?.DisplayName!;
        }


        [RelayCommand]
        async Task UserImageOptions() {

            string action = await Shell.Current.DisplayActionSheet("What do you want to do: ",
                "Cancel", null,
                "Take a picture",
                "Pick an image from the gallery");

            switch(action) {

                case "Take a picture":

                    var photoResult = await _mediaPicker.CapturePhotoAsync(new MediaPickerOptions {
                        Title = "Take a picture"
                    });
                    if(photoResult != null) {
                        // Save the photo to the local file system
                        var newFileName = $"{User.Username}_Profile.jpg";
                        var newFilePath = Path.Combine(FileSystem.CacheDirectory, newFileName);
                        using var stream = await photoResult.OpenReadAsync();
                        using var reader = new StreamReader(stream);
                        using var fileStream = File.OpenWrite(newFilePath);
                        await stream.CopyToAsync(fileStream);
                    }

                    break;
                case "Pick an image from the gallery":
                    var result = await _mediaPicker.PickPhotoAsync(new MediaPickerOptions {
                        Title = "Pick an image from the gallery"
                    });
                    if(result != null) {
                        User.ImagePath = result.FullPath;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
