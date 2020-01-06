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
            // Create easy game board form
            EasyGameBoard easyGameBoard = new EasyGameBoard();

            // When the easy form is closed show the main menu form
            easyGameBoard.Closed += (s, args) => this.ShowForm("MainMenu");

            // Show the easy board form
            easyGameBoard.Show();

            // Hide the main menu form
            this.Hide();
        }

        // When the Medium Button is clicked
        private void MediumModeButton_Click(object sender, EventArgs e)
        {
            // Create Medium game board form
            MediumGameBoard mediumGameBoard = new MediumGameBoard();

            // When the medium board is closed show the main menu form
            mediumGameBoard.Closed += (s, args) => this.ShowForm("MainMenu");

            // Show the medium board form
            mediumGameBoard.Show();

            // Hide the main menu form
            this.Hide();
        }

        // When the Hard button is clicked
        private void HardModeButton_Click(object sender, EventArgs e)
        {
            // Create Hard game board form
            HardGameBoard hardGameBoard = new HardGameBoard();

            // When the Hard board is closed show the main menu form
            hardGameBoard.Closed += (s, args) => this.ShowForm("MainMenu");

            // Show the Hard board form
            hardGameBoard.Show();

            // Hide the main menu form
            this.Hide();
        }

        // When the Leaderboard button is clicked
        private void leaderboardButton_Click(object sender, EventArgs e)
        {
            // Create new leaderboard form view
            LeaderboardView leaderboardView = new LeaderboardView();

            // Show the form
            leaderboardView.Show();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        // Show the form with the passed form name
        private void ShowForm(string formName)
        {
            // Go through all open forms in the application
            foreach (Form form in Application.OpenForms)
            {
                // Get the current form name
                string currentFormName = form.Name;

                // If the current form name is equal to the passed one 
                if (currentFormName == formName)
                {
                    // Show the form
                    form.Show();
                }
            }
        }
    }
}
