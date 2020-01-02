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
            this.easyButton.PerformClick();
        }

        // When the Easy button is clicked
        private async void easyButton_Click(object sender, EventArgs e)
        {
            this.easyButton.BackColor = SystemColors.AppWorkspace;
            this.mediumButton.BackColor = SystemColors.Control;
            this.hardButton.BackColor = SystemColors.Control;

            this.leaderboardManager = new LeaderboardManager(Gamemode.Easy);

            List<LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();
            this.FillListView(leaderboardData);
        }

        // When the Medium button is clicked
        private async void mediumButton_Click(object sender, EventArgs e)
        {
            this.easyButton.BackColor = SystemColors.Control;
            this.mediumButton.BackColor = SystemColors.AppWorkspace;
            this.hardButton.BackColor = SystemColors.Control;

            this.leaderboardManager = new LeaderboardManager(Gamemode.Medium);

            List< LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();
            this.FillListView(leaderboardData);
        }

        // When the Hard button is clicked
        private async void hardButton_Click(object sender, EventArgs e)
        {
            this.easyButton.BackColor = SystemColors.Control;
            this.mediumButton.BackColor = SystemColors.Control;
            this.hardButton.BackColor = SystemColors.AppWorkspace;

            this.leaderboardManager = new LeaderboardManager(Gamemode.Hard);

            List< LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();
            this.FillListView(leaderboardData);
        }

        // Fills the list view component with the leaderboard data
        private void FillListView(List<LeaderboardData> leaderboard)
        {
            this.leaderboardListView.Items.Clear();

            int counter = 1;
            foreach (var record in leaderboard.OrderByDescending(l => l.Score))
            {
                string rank = counter < 10 ? "0" + counter : counter.ToString();

                string result = $@"      {rank}.         {record.Username} - {record.Score}";

                ListViewItem listViewItem = new ListViewItem(result);
                listViewItem.IndentCount = 4;

                this.leaderboardListView.Items.Add(listViewItem);

                counter++;
            }
        }
    }
}
