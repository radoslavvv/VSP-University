using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSP_4153_MyProject.Forms
{
    public class Leaderboard
    {
        public Leaderboard()
        {
            this.Data = new List<LeaderboardData>();
        }

        public List<LeaderboardData> Data { get; private set; }
    }
}
