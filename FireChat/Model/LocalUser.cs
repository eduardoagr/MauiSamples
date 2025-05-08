namespace FireChat.Model {

    [FirestoreData]
    public class LocalUser {

        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string ConfirmPassword { get; set; }

        [FirestoreProperty]
        public string ImagePath { get; set; }

        [FirestoreProperty]
        public string StatusMessage { get; set; } = "Hey there! I'm using FireChat!";

        [FirestoreProperty]
        public bool OnlineStatus { get; set; } = true;
    }
}
