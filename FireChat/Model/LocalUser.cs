namespace FireChat.Model {

    public partial class LocalUser : ObservableObject {

        [ObservableProperty]
        string _username;

        [ObservableProperty]
        string _email;

        [ObservableProperty]
        string _password;

        [ObservableProperty]
        string _confirmPassword;
    }
}
