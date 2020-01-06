using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSP_4153_MyProject.Forms
{
    public partial class LeaderboardPrompt : Form
    {
        private int playerScore;
        private LeaderboardController leaderboardManager;

        public LeaderboardPrompt(int playerScore, LeaderboardController leaderboardManager)
        {
            // Set the current player's score
            this.playerScore = playerScore;
            this.leaderboardManager = leaderboardManager;

            InitializeComponent();

            // Hide the error message
            errorMessage.Visible = false;
        }

        // When the Enter button is clicked
        private async void enterButton_Click(object sender, EventArgs e)
        {
            // Get the data for the leaderboard from the database
            List<LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();

            // If the nickname entered is empty or null 
            if (nicknameTextBox.Text.Trim().Length == 0 || string.IsNullOrEmpty(nicknameTextBox.Text.Trim()))
            {
                // Show error message
                errorMessage.Text = "This username is invalid!";
                errorMessage.Visible = true;
            }
            else if(nicknameTextBox.Text.Trim().Length > 5)
            {
                // Show error message
                errorMessage.Text = "This username is too long! Please enter a shorter one!";
                errorMessage.Visible = true;
            }
            else
            {
                // Get the entered username
                string username = nicknameTextBox.Text;

                // If someone on the leaderboard has the same name
                if (leaderboardData.Any(r => r.Username == username))
                {
                    // Show error message
                    errorMessage.Text = "This username is already taken! Please use another!";
                    errorMessage.Visible = true;
                }
                else
                {
                    // If the people in the leaderboard are less than 10
                    if(leaderboardData.Count < 10)
                    {
                        // Just add the person's record to the database
                        await this.leaderboardManager.AddRecord(username, this.playerScore);
                    }
                    else
                    {
                        // Get the person in the last place with the lowest score
                        LeaderboardData lastPlace = leaderboardData.OrderByDescending(l => l.Score).Last();

                        // Remove him from the database
                        await this.leaderboardManager.RemoveRecord(lastPlace);

                        // Add the new record in the database
                        await this.leaderboardManager.AddRecord(username, this.playerScore);
                    }

                    // Then close the form
                    this.Close();
                }
            }
        }

        // When the cancel button is clicked
        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
