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

        private void LeaderboardView_Load(object sender, EventArgs e)
        {
            this.easyButton.PerformClick();
        }

        private async void easyButton_Click(object sender, EventArgs e)
        {
            this.leaderboardManager = new LeaderboardManager(Gamemode.Easy);

            Leaderboard leaderboard = await this.leaderboardManager.GetLeaderboard();
            this.FillListView(leaderboard);
        }

        private async void mediumButton_Click(object sender, EventArgs e)
        {
            this.leaderboardManager = new LeaderboardManager(Gamemode.Medium);

            Leaderboard leaderboard = await this.leaderboardManager.GetLeaderboard();
            this.FillListView(leaderboard);
        }

        private async void hardButton_Click(object sender, EventArgs e)
        {
            this.leaderboardManager = new LeaderboardManager(Gamemode.Hard);

            Leaderboard leaderboard = await this.leaderboardManager.GetLeaderboard();
            this.FillListView(leaderboard);
        }

        private void FillListView(Leaderboard leaderboard)
        {
            this.leaderboardListView.Items.Clear();

            int counter = 1;
            foreach (var record in leaderboard.Data.OrderByDescending(l => l.Score))
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
