namespace FireChat.Model {

    public partial class LocalUser : BaseViewModel {

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
