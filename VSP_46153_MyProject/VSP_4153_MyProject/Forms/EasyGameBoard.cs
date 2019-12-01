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
    public partial class EasyGameBoard : Form
    {
        private GameManager gameManager;

        public EasyGameBoard()
        {
            InitializeComponent();
            this.gameManager = new GameManager(this, Constants.EasyGameBoardSize,
                Constants.EasyGameBoardStartSpeed, Constants.EasyGameBoardMaxSpeed,
                Constants.EasyGameBoardSpeedIncrease, Constants.EasyGameBoardMaxBlocksCount);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.gameManager.UpdatePlayerScore();
            StartButton.Visible = false;
            ReturnHomeButton.Visible = false;

            this.gameManager.StartGame();
        }

        private void GameBlockClick(object sender, EventArgs e)
        {
            Control clickedGameBlock = (Control)sender;

            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            this.Close();

            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void EasyGameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
