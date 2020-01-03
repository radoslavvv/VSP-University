using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSP_4153_MyProject.Forms
{
    public partial class LeaderboardView : Form
    {
        private LeaderboardManager leaderboardManager;

        public LeaderboardView()
        {
            InitializeComponent();
        }

        // When the form loads
        private void LeaderboardView_Load(object sender, EventArgs e)
        {
            // Click on the Easy button
            this.easyButton.PerformClick();
        }

        // When the Easy button is clicked
        private void easyButton_Click(object sender, EventArgs e)
        {
            // Change the color of the Easy button to Dark Gray
            this.easyButton.BackColor = SystemColors.AppWorkspace;

            // Change the colors of the Medium and Hard buttons to default - Light Gray
            this.mediumButton.BackColor = SystemColors.Control;
            this.hardButton.BackColor = SystemColors.Control;

            // Fill the leaderboard view with data for the current game mode
            this.FillListView(Gamemode.Easy);
        }

        // When the Medium button is clicked
        private void mediumButton_Click(object sender, EventArgs e)
        { 
            // Change the color of the Medium button to Dark Gray
            this.mediumButton.BackColor = SystemColors.AppWorkspace;

            // Change the colors of the Easy and Hard buttons to default - Light Gray
            this.easyButton.BackColor = SystemColors.Control;
            this.hardButton.BackColor = SystemColors.Control;

            // Fill the leaderboard view with data for the current game mode
            this.FillListView(Gamemode.Medium);
        }

        // When the Hard button is clicked
        private void hardButton_Click(object sender, EventArgs e)
        {
            // Change the color of the Medium button to Dark Gray
            this.hardButton.BackColor = SystemColors.AppWorkspace;

            // Change the colors of the Easy and Medium buttons to default - Light Gray
            this.easyButton.BackColor = SystemColors.Control;
            this.mediumButton.BackColor = SystemColors.Control;

            // Fill the leaderboard view with the data for the current game mode
            this.FillListView(Gamemode.Hard);
        }

        // Fills the list view component with the leaderboard data for the passed game mode
        private async void FillListView(Gamemode currentGameMode)
        {
            // Creates the leaderboard manager for the passed gamemode
            this.leaderboardManager = new LeaderboardManager(currentGameMode);

            // Clear the leaderboard view of any items
            this.leaderboardListView.Items.Clear();

            // Get the leaderboard data from the database
            List<LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();

            // Goes through each record of the database ordered by score in descending order
            int counter = 1;
            foreach (var record in leaderboardData.OrderByDescending(l => l.Score))
            {
                // Form the rank of each score - if it's below 10 add a zero ifront of the digit
                string rank = counter < 10 ? "0" + counter : counter.ToString();

                // Form the rank row
                string result = $@"      {rank}.         {record.Username} - {record.Score}";

                // Create list view item with the formated result
                ListViewItem listViewItem = new ListViewItem(result);
                listViewItem.IndentCount = 4;

                // Add the list view item inside the listview
                this.leaderboardListView.Items.Add(listViewItem);

                // Increase the counter
                counter++;
            }
        }
    }
}
