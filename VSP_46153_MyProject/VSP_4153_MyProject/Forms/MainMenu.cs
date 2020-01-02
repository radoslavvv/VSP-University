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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // When the Easy button is clicked
        private void EasyModeButton_Click(object sender, EventArgs e)
        {
            //EasyGameBoard easyBoard = new EasyGameBoard();
            //easyBoard.Show();
            //easyBoard.FormClosing += (obj, args) => { this.Close(); };
            //this.Hide();

            //this.Hide();

            //EasyGameBoard easyGameBoard = new EasyGameBoard();
            //easyGameBoard.ShowDialog();

            //this.Close();

            EasyGameBoard easyGameBoard = new EasyGameBoard();
            easyGameBoard.Closed += (s, args) => this.ShowForm("MainMenu");
            easyGameBoard.Show();
            this.Hide();
        }


        // When the Medium Button is clicked
        private void MediumModeButton_Click(object sender, EventArgs e)
        {
            //MediumGameBoard mediumBoard = new MediumGameBoard();
            //mediumBoard.Show();
            //mediumBoard.FormClosing += (obj, args) => { this.Close(); };

            //this.Hide();

            //this.Hide();

            //MediumGameBoard mediumBoard = new MediumGameBoard();
            //mediumBoard.ShowDialog();

            //this.Close();

            MediumGameBoard mediumGameBoard = new MediumGameBoard();
            mediumGameBoard.Closed += (s, args) => this.ShowForm("MainMenu");
            mediumGameBoard.Show();
            this.Hide();
        }

        // When the Hard button is clicked
        private void HardModeButton_Click(object sender, EventArgs e)
        {
            //HardGameBoard hardBoard = new HardGameBoard();
            //hardBoard.Show();
            //hardBoard.FormClosing += (obj, args) => { this.Close(); };

            //this.Hide();

            //this.Hide();

            //HardGameBoard hardBoard = new HardGameBoard();
            //hardBoard.ShowDialog();

            //this.Close();

            HardGameBoard hardGameBoard = new HardGameBoard();
            hardGameBoard.Closed += (s, args) => this.ShowForm("MainMenu");
            hardGameBoard.Show();
            this.Hide();
        }

        // When the Leaderboard button is clicked
        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            LeaderboardView leaderboardView = new LeaderboardView();
            leaderboardView.Show();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void ShowForm(string formName)
        {
            foreach (Form form in Application.OpenForms)
            {
                string currentFormName = form.Name;
                if(currentFormName == formName)
                {
                    form.Show();
                }
            }
        }
    }
}
