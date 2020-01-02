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
            Control clickedGameBlock = (Control)sender;

            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        // When the Start Button is clicked
        private void StartButtonClick(object sender, EventArgs e)
        {
            this.gameManager.UpdatePlayerScore();
            StartButton.Visible = false;
            ReturnHomeButton.Visible = false;

            this.gameManager.StartGame();
        }

        // When the Return Home button is clicked
        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            //this.Close();

            //MainMenu mainMenu = new MainMenu();
            //mainMenu.Show();



            //this.Hide();

            //MainMenu mainMenu = new MainMenu();
            //mainMenu.ShowDialog();

            //this.Close();

            this.Close();
            //MainMenu mainmenu = new MainMenu();
            //mainmenu.Closed += (s, args) => this.Close();
            //mainmenu.Show();
        }
    }
}
