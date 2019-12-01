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
            this.Close();

            EasyGameBoard easyBoard = new EasyGameBoard();
            easyBoard.Show();
        }

        private void MediumModeButton_Click(object sender, EventArgs e)
        {
            this.Close();

            MediumGameBoard mediumBoard = new MediumGameBoard();
            mediumBoard.Show();
        }

        private void HardModeButton_Click(object sender, EventArgs e)
        {
            this.Close();

            HardGameBoard hardBoard = new HardGameBoard();
            hardBoard.Show();
        }
    }
}
