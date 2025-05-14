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

        public async Task CreateAsync<T>(T entity, string collectionName, string documentId) {
            if(db == null) {
                await InitializeFirebaseAsync(); // Ensure Firestore is initialized
            }

            DocumentReference docRef = db!.Collection(collectionName).Document(documentId);

            // Set the Id property of the entity to the documentId
            var idProperty = typeof(T).GetProperty("Id");
            if(idProperty != null && idProperty.PropertyType == typeof(string)) {
                idProperty.SetValue(entity, documentId);
            }


            // Convert object to dictionary using reflection
            Dictionary<string, object> entityData = [];
            foreach(var prop in typeof(T).GetProperties()) {

                if(prop.Name != "Password" && prop.Name != "ConfirmPassword") {

                    entityData[prop.Name] = prop.GetValue(entity)!;
                }
            }

            await docRef.SetAsync(entityData);
        }
    }
}
