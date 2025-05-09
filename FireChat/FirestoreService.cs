namespace FireChat {

    public class FirestoreService {

        private FirestoreDb? db;

        public async Task InitializeFirebaseAsync() {

            if(db == null) {
                using var stream = await FileSystem.OpenAppPackageFileAsync("firebase-adminsdk.json");
                using var reader = new StreamReader(stream);
                string json = await reader.ReadToEndAsync();

                db = new FirestoreDbBuilder() {
                    ProjectId = Credentials.FirebaseProjectId,
                    JsonCredentials = json
                }.Build();
            }
        }

        public async Task CreateUserAsync(LocalUser user, string Id) {
            if(db == null) {
                await InitializeFirebaseAsync(); // Ensure Firestore is initialized
            }

            user.Id = Id; // Set the user ID

            DocumentReference docRef = db!.Collection("users").Document(user.Id);
            await docRef.SetAsync(new Dictionary<string, object> {

                { "Id", user.Id },
                { "Username", user.Username },
                { "Email", user.Email },
                { "ImagePath", user.ImagePath },
                { "StatusMessage", user.StatusMessage },
                { "OnlineStatus", user.OnlineStatus }

            });
        }

        public async Task UpdateUserAsync(LocalUser user) {
            if(db == null) {
                await InitializeFirebaseAsync();
            }

            DocumentReference docRef = db!.Collection("users").Document(user.Id);
            await docRef.UpdateAsync(new Dictionary<string, object>
            {
                { "Username", user.Username },
                { "ImagePath", user.ImagePath },
                { "StatusMessage", user.StatusMessage }

            });
        }
    }
}
