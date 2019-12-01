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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void EasyModeButton_Click(object sender, EventArgs e)
        {
            //EasyGameBoard easyBoard = new EasyGameBoard();
            //easyBoard.Show();
            //easyBoard.FormClosing += (obj, args) => { this.Close(); };
            //this.Hide();

            this.Hide();

            EasyGameBoard easyGameBoard = new EasyGameBoard();
            easyGameBoard.ShowDialog();

            this.Close();
        }

        private void MediumModeButton_Click(object sender, EventArgs e)
        {
            //MediumGameBoard mediumBoard = new MediumGameBoard();
            //mediumBoard.Show();
            //mediumBoard.FormClosing += (obj, args) => { this.Close(); };

            //this.Hide();

            this.Hide();

            MediumGameBoard mediumBoard = new MediumGameBoard();
            mediumBoard.ShowDialog();

            this.Close();
        }

        private void HardModeButton_Click(object sender, EventArgs e)
        {
            //HardGameBoard hardBoard = new HardGameBoard();
            //hardBoard.Show();
            //hardBoard.FormClosing += (obj, args) => { this.Close(); };

            //this.Hide();

            this.Hide();

            HardGameBoard hardBoard = new HardGameBoard();
            hardBoard.ShowDialog();

            this.Close();
        }
    }
}
