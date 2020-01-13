using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSP_4153_MyProject
{
    public class Constants
    {
        // Common Constants
        public const int StartBlocksCount = 5;

        public const int GeneratingBlocksDelay = 1000;

        public const int CheckSelectedBoxesDelay = 200;

        public const int StartNewRoundDelay = 300;

        public const int SpeedIncreaseRoundsCount = 3;

        // Easy Board Constants
        public const int EasyGameBoardSize = 4;

        public const int EasyGameBoardStartSpeed = 1000;

        public const int EasyGameBoardMaxSpeed = 10;

        public const int EasyGameBoardSpeedIncrease = 10;

        public const int EasyGameBoardMaxBlocksCount = 10;

        // Medium Board Constants
        public const int MediumGameBoardSize = 5;

        public const int MediumGameBoardStartSpeed = 750;

        public const int MediumGameBoardMaxSpeed = 5;

        public const int MediumGameBoardSpeedIncrease = 25;

        public const int MediumGameBoardMaxBlocksCount = 15;


        // Hard Board Constants
        public const int HardGameBoardSize = 6;

        public const int HardGameBoardStartSpeed = 600;

        public const int HardGameBoardMaxSpeed = 1;

        public const int HardGameBoardSpeedIncrease = 35;

        public const int HardGameBoardMaxBlocksCount = 22;
    }
}
