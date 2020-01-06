using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSP_4153_MyProject.Forms
{
    public class LeaderboardController
    {
        private IFirebaseConfig firebaseConfig;
        private IFirebaseClient firebaseClient;
        private Gamemode gameMode;

        public LeaderboardController(Gamemode gameMode)
        {
            // Configure the firebase configuration for the firesharp plugin
            this.firebaseConfig = new FirebaseConfig()
            {
                AuthSecret = "biDqRu7XIL1v3Fl9vTZxRBWQwg4LJot1TMih1wj4",
                BasePath = "https://vsp-memory-leaderboard-7a822.firebaseio.com/",
            };

            // Create a new firebase client with the firebase configuration
            this.firebaseClient = new FirebaseClient(this.firebaseConfig);

            // Set the gamemode to the passed gamemode
            this.gameMode = gameMode;
        }

        // Retrieves all the records inside the database for the current game mode
        public async Task<List<LeaderboardData>> GetLeaderboard()
        {
            List<LeaderboardData> currentLeaderboardData = new List<LeaderboardData>();

            // Send a get request to the database - getting all records for the current gamemode
            FirebaseResponse response = await this.firebaseClient.GetAsync($"{this.gameMode.ToString()}/");

            // If the request response is not null
            if (response.Body != "null")
            {
                // Parse the JSON response to JObject
                JObject jobject = JObject.Parse(response.Body);

                // Go through each user record in the jobject
                foreach (var user in jobject)
                {
                    // Get the record's username
                    string username = user.Key;

                    // Get the record's data for the current user
                    JToken userData = user.Value;

                    // Get the record's date
                    DateTime date = DateTime.Parse(userData["Date"].ToString());

                    // Get the record's score
                    int score = int.Parse(userData["Score"].ToString());

                    // Form a object with the collected data
                    LeaderboardData currentLeaderBoardData = new LeaderboardData()
                    {
                        Username = username,
                        Date = date,
                        Score = score
                    };

                    // Add the created object to the leaderboard
                    currentLeaderboardData.Add(currentLeaderBoardData);
                }
            }

            // Return the leaderboard data
            return currentLeaderboardData;
        }

        // Adds a new record to the database
        public async Task<LeaderboardData> AddRecord(string username, int score)
        {
            // List<LeaderboardData> currentLeaderboardData = await this.GetLeaderboard();

            // Create a new object holding the data for the current record
            LeaderboardData leaderboardData = new LeaderboardData()
            {
                Username = username,
                Date = DateTime.Now,
                Score = score
            };

            // Crate the path to the record - Gamemode/username
            string path = $"{this.gameMode.ToString()}/" + leaderboardData.Username;

            // Send the create request to the database
            SetResponse response = await this.firebaseClient.SetAsync(path, leaderboardData);
            LeaderboardData data = response.ResultAs<LeaderboardData>();

            return data;
        }

        // Removes a specific record from the database
        public async Task<FirebaseResponse> RemoveRecord(LeaderboardData leaderboardData)
        {
            // Crate the path to the record - Gamemode/username
            string path = $"{this.gameMode.ToString()}/{leaderboardData.Username}";

            // Send the remove request to the database
            FirebaseResponse response = await this.firebaseClient.DeleteAsync(path);

            return response;
        }
    }
}
