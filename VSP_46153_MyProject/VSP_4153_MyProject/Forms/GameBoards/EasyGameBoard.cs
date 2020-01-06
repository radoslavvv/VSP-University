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
    public partial class EasyGameBoard : Form
    {
        private GameController gameManager;
        private LeaderboardController leaderBoardManager;

        public EasyGameBoard()
        {
            InitializeComponent();

            this.leaderBoardManager = new LeaderboardController(Gamemode.Easy);

            this.gameManager = new GameController(this, 
                this.leaderBoardManager,
                Constants.EasyGameBoardSize,
                Constants.EasyGameBoardStartSpeed, 
                Constants.EasyGameBoardMaxSpeed,
                Constants.EasyGameBoardSpeedIncrease, 
                Constants.EasyGameBoardMaxBlocksCount);
        }

        // When the Start button is clicked
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Update the player's score
            this.gameManager.UpdatePlayerScore();

            // Hide Start and Return Home buttons
            StartButton.Visible = false;
            ReturnHomeButton.Visible = false;

            // Start the game
            this.gameManager.StartGame();
        }

        // When a game block is clicked
        private void GameBlockClick(object sender, EventArgs e)
        {
            // Get the clicked block
            Control clickedGameBlock = (Control)sender;

            // Handle game block click
            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        // When the Return Home button is clicked
        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
