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
        private LeaderboardManager leaderboardManager;
        private int playerScore;

        public LeaderboardPrompt(int playerScore, LeaderboardManager leaderboardManager)
        {
            this.playerScore = playerScore;
            this.leaderboardManager = leaderboardManager;


            InitializeComponent();

            errorMessage.Visible = false;
        }

        private async void enterButton_Click(object sender, EventArgs e)
        {
            Leaderboard leaderboard = await this.leaderboardManager.GetLeaderboard();

            if (nicknameTextBox.Text.Length == 0 || string.IsNullOrEmpty(nicknameTextBox.Text))
            {
                errorMessage.Text = "This username is invalid!";
                errorMessage.Visible = true;
            }
            else
            {
                string nickname = nicknameTextBox.Text;

                if (leaderboard.Data.Any(r => r.Username == nickname))
                {
                    errorMessage.Text = "This username is already taken! Please use another!";
                    errorMessage.Visible = true;
                }
                else
                {
                    if(leaderboard.Data.Count < 10)
                    {
                        await this.leaderboardManager.AddRecord(nickname, this.playerScore);
                    }
                    else
                    {
                        LeaderboardData lastPlace = leaderboard.Data.OrderByDescending(l => l.Score).Last();
                        await this.leaderboardManager.RemoveRecord(lastPlace);
                        await this.leaderboardManager.AddRecord(nickname, this.playerScore);
                    }

                    this.Close();
                }
            }
        }

        private void cancelButton_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
