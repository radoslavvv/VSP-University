using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSP_4153_MyProject.Forms;

namespace VSP_4153_MyProject
{
    public partial class MediumGameBoard : Form
    {
        private GameManager gameManager;
        private LeaderboardManager leaderboardManager;

        public MediumGameBoard()
        {
            InitializeComponent();

            this.leaderboardManager = new LeaderboardManager(Gamemode.Medium);
            this.gameManager = new GameManager(this, 
                this.leaderboardManager,
                Constants.MediumGameBoardSize,
                Constants.MediumGameBoardStartSpeed, 
                Constants.MediumGameBoardMaxSpeed,
                Constants.MediumGameBoardSpeedIncrease, 
                Constants.MediumGameBoardMaxBlocksCount);
        }

        // When a Game Block is clicked
        private void GameBlockClick(object sender, EventArgs e)
        {
            // Get clicked game block
            Control clickedGameBlock = (Control)sender;

            // Handle game block click
            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        // When the Start Button is clicked
        private void StartButtonClick(object sender, EventArgs e)
        {
            // Update player's score
            this.gameManager.UpdatePlayerScore();

            // Hide Start and Return Home buttons
            StartButton.Visible = false;
            ReturnHomeButton.Visible = false;

            // Start a new game
            this.gameManager.StartGame();
        }

        // When the Return Home button is clicked
        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
