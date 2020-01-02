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
        private LeaderboardManager leaderboardManager;

        public LeaderboardPrompt(int playerScore, LeaderboardManager leaderboardManager)
        {
            this.playerScore = playerScore;
            this.leaderboardManager = leaderboardManager;


            InitializeComponent();

            errorMessage.Visible = false;
        }

        // When the Enter button is clicked
        private async void enterButton_Click(object sender, EventArgs e)
        {
            List<LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();

            if (nicknameTextBox.Text.Length == 0 || string.IsNullOrEmpty(nicknameTextBox.Text))
            {
                errorMessage.Text = "This username is invalid!";
                errorMessage.Visible = true;
            }
            else
            {
                string username = nicknameTextBox.Text;

                if (leaderboardData.Any(r => r.Username == username))
                {
                    errorMessage.Text = "This username is already taken! Please use another!";
                    errorMessage.Visible = true;
                }
                else
                {
                    if(leaderboardData.Count < 10)
                    {
                        await this.leaderboardManager.AddRecord(username, this.playerScore);
                    }
                    else
                    {
                        LeaderboardData lastPlace = leaderboardData.OrderByDescending(l => l.Score).Last();
                        await this.leaderboardManager.RemoveRecord(lastPlace);
                        await this.leaderboardManager.AddRecord(username, this.playerScore);
                    }

                    this.Close();
                }
            }
        }

        // When the cancel button is clicked
        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
