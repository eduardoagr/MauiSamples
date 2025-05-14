namespace FireChat.Model;

[FirestoreData]
public partial class LocalUser : ObservableObject {

    [FirestoreProperty]
    [ObservableProperty]
    public partial string Id { get; set; }

    [FirestoreProperty]
    [ObservableProperty]
    public partial string Username { get; set; }

    [FirestoreProperty]
    [ObservableProperty]
    public partial string Email { get; set; }

    [FirestoreProperty]
    [ObservableProperty]
    public partial string Password { get; set; }

    [FirestoreProperty]
    [ObservableProperty]
    public partial string ConfirmPassword { get; set; }

    [FirestoreProperty]
    [ObservableProperty]
    public partial string ImagePath { get; set; }

    [FirestoreProperty]
    [ObservableProperty]
    public partial string StatusMessage { get; set; } = "Hey there! I'm using FireChat!";

    [FirestoreProperty]
    [ObservableProperty]
    public partial bool OnlineStatus { get; set; } = true;
}