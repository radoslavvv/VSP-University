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
    public partial class GameBoard4By4 : Form
    {
        private GameManager gameManager;

        public GameBoard4By4()
        {
            InitializeComponent();
            this.gameManager = new GameManager(this);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.gameManager.UpdatePlayerScore(0);
            StartButton.Visible = false;

            this.gameManager.StartGame();
        }

        private void GameBlockClick(object sender, EventArgs e)
        {
            Control clickedGameBlock = (Control)sender;

            this.gameManager.HandleGameBlockClick(clickedGameBlock);
        }
    }
}
