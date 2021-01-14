using Google.Cloud.Firestore;

namespace FirebaseApp
{
    [FirestoreData]
    public class Response
    {
        [FirestoreProperty]
        public bool Ok { get; set; }
    }
}
