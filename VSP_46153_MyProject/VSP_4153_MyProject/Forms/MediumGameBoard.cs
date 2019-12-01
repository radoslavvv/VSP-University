using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSP_4153_MyProject
{
    public partial class MediumGameBoard : Form
    {
        private GameManager gameManager;

        public MediumGameBoard()
        {
            InitializeComponent();
            this.gameManager = new GameManager(this, Constants.MediumGameBoardSize,
                Constants.MediumGameBoardStartSpeed, Constants.MediumGameBoardMaxSpeed,
                Constants.MediumGameBoardSpeedIncrease, Constants.MediumGameBoardMaxBlocksCount);
        }

        private void GameBlockClick(object sender, EventArgs e)
        {
            Control clickedGameBlock = (Control)sender;

            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            this.gameManager.UpdatePlayerScore();
            StartButton.Visible = false;
            ReturnHomeButton.Visible = false;

            this.gameManager.StartGame();
        }

        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
