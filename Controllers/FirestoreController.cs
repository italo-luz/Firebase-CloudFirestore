using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FirebaseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirestoreController : ControllerBase
    {
        string projectId;
        FirestoreDb fireStoreDb;

        public FirestoreController()
        {
            string filepath = "C:\\FirestoreAPIKey\\fir-mvcsample-73b70-1ee7b1a69445.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "fir-mvcsample-73b70";
            fireStoreDb = FirestoreDb.Create(projectId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create a document with a random ID in the "cities" collection.
            //CollectionReference collection = fireStoreDb.Collection("prevent-fraud");
            //var response = new Response() { Ok = true };
            //await collection.Document("456").CreateAsync(response);

            // Update
            //DocumentReference empRef = fireStoreDb.Collection("prevent-fraud").Document("12345");
            //await empRef.SetAsync(response, SetOptions.Overwrite);


            //DocumentReference document = await collection.AddAsync(city);

            //CollectionReference colRef = fireStoreDb.Collection("prevent-fraud");
            //DocumentReference londonFromDb = fireStoreDb.Document("cities/london");

            //await collection.Document("los-angeles").CreateAsync(city);
            //await colRef.AddAsync(city);

            // Read
            DocumentReference docRef = fireStoreDb.Collection("prevent-fraud").Document("12345");
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            var resp = snapshot.ConvertTo<Response>();
            return Ok(resp);
        }
    }
}
