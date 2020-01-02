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
        private GameManager gameManager;
        private LeaderboardManager leaderBoardManager;

        public EasyGameBoard()
        {
            InitializeComponent();

            this.leaderBoardManager = new LeaderboardManager(Gamemode.Easy);

            this.gameManager = new GameManager(this, 
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
            this.gameManager.UpdatePlayerScore();
            StartButton.Visible = false;
            ReturnHomeButton.Visible = false;

            this.gameManager.StartGame();
        }

        // When a game block is clicked
        private void GameBlockClick(object sender, EventArgs e)
        {
            Control clickedGameBlock = (Control)sender;

            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        // When the Return Home button is clicked
        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            //MainMenu mainmenu = new MainMenu();
            //mainmenu.Closed += (s, args) => this.Close();
            //mainmenu.Show();

            //this.Hide();

            //MainMenu mainMenu = new MainMenu();
            //mainMenu.ShowDialog();

            //this.Close();
        }
        
        //// When the form closes
        //private void EasyGameBoard_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
