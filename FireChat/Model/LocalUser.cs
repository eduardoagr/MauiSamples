namespace FireChat.Model {

    [FirestoreData]
    public partial class LocalUser : ObservableObject {

        private string _id;
        private string _username;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _imagePath;
        private string _statusMessage = "Hey there! I'm using FireChat!";
        private bool _onlineStatus = true;

        [FirestoreProperty]
        public string Id {
            get => _id;
            set {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [FirestoreProperty]
        public string Username {
            get => _username;
            set {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        [FirestoreProperty]
        public string Email {
            get => _email;
            set {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [FirestoreProperty]
        public string Password {
            get => _password;
            set {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        [FirestoreProperty]
        public string ConfirmPassword {
            get => _confirmPassword;
            set {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        [FirestoreProperty]
        public string ImagePath {
            get => _imagePath;
            set {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        [FirestoreProperty]
        public string StatusMessage {
            get => _statusMessage;
            set {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        [FirestoreProperty]
        public bool OnlineStatus {
            get => _onlineStatus;
            set {
                _onlineStatus = value;
                OnPropertyChanged(nameof(OnlineStatus));
            }
        }
    }
}