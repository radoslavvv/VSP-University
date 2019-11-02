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
    public partial class GameBoard5By5 : Form
    {
        private GameManager gameManager;

        public GameBoard5By5()
        {
            InitializeComponent();
            this.gameManager = new GameManager(this, 5);
        }

        private void GameBlockClick(object sender, EventArgs e)
        {
            Control clickedGameBlock = (Control)sender;

            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            this.gameManager.UpdatePlayerScore(0);
            StartButton.Visible = false;

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
