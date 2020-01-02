﻿using FireSharp;
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
    public class LeaderboardManager
    {
        private IFirebaseConfig firebaseConfig;
        private IFirebaseClient firebaseClient;
        private Gamemode gameMode;

        public LeaderboardManager(Gamemode gameMode)
        {
            this.firebaseConfig = new FirebaseConfig()
            {
                AuthSecret = "",
                BasePath = "",
            };

            this.firebaseClient = new FirebaseClient(this.firebaseConfig);
            this.gameMode = gameMode;
        }

        // Retrieves all the records inside the database for the current game mode
        public async Task<List<LeaderboardData>> GetLeaderboard()
        {
            List<LeaderboardData> currentLeaderboardData = new List<LeaderboardData>();

            FirebaseResponse response = await this.firebaseClient.GetAsync($"{this.gameMode.ToString()}/");

            if (response.Body != "null")
            {
                JObject jobject = JObject.Parse(response.Body);
                foreach (var user in jobject)
                {
                    string username = user.Key;
                    JToken userData = user.Value;
                    DateTime date = DateTime.Parse(userData["Date"].ToString());
                    int score = int.Parse(userData["Score"].ToString());

                    LeaderboardData currentLeaderBoardData = new LeaderboardData()
                    {
                        Username = username,
                        Date = date,
                        Score = score
                    };

                    currentLeaderboardData.Add(currentLeaderBoardData);
                }
            }

            return currentLeaderboardData;
        }

        // Adds a new record to the database
        public async Task<LeaderboardData> AddRecord(string username, int score)
        {
            // List<LeaderboardData> currentLeaderboardData = await this.GetLeaderboard();

            LeaderboardData leaderboardData = new LeaderboardData()
            {
                Username = username,
                Date = DateTime.Now,
                Score = score
            };

            SetResponse response = await this.firebaseClient.SetAsync($"{this.gameMode.ToString()}/" + leaderboardData.Username, leaderboardData);
            LeaderboardData data = response.ResultAs<LeaderboardData>();

            return data;
        }

        // Removes a specific record from the database
        public async Task<FirebaseResponse> RemoveRecord(LeaderboardData leaderboardData)
        {
            string path = $"{this.gameMode.ToString()}/{leaderboardData.Username}";
            FirebaseResponse response = await this.firebaseClient.DeleteAsync(path);

            return response;
        }
    }
}