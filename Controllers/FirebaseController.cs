using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirebaseApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirebaseController : ControllerBase
    {
        private readonly ILogger<FirebaseController> _logger;

        public FirebaseController(ILogger<FirebaseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";

            //Save non identifying data to Firebase
            var currentUserLogin = new LoginData() { SasStatus = "SuspectedFraudDiscarded" };
            var firebaseClient = new FirebaseClient("https://fir-mvcsample-73b70-default-rtdb.firebaseio.com/");

            var result = await firebaseClient
              .Child("Users/" + userId + "/Requests")
              .PostAsync(currentUserLogin);

            //Retrieve data from Firebase
            var dbLogins = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Requests")
              .OnceAsync<LoginData>();

            var requestsList = new List<string>();

            //Convert JSON data to original datatype
            foreach (var login in dbLogins)
            {
                requestsList.Add(login.Object.SasStatus);
            }

            return Ok(requestsList);
        }
    }
}
