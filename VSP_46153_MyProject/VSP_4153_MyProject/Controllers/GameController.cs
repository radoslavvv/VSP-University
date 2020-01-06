using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSP_4153_MyProject.Forms;
using static System.Windows.Forms.Control;

namespace VSP_4153_MyProject
{
    public class GameController
    {
        private LeaderboardController leaderboardManager;
        private Form gameBoard;
        private int requredCurrentLevelBlocks;
        private int maxBlocksCount;
        private bool blockSelectionIsEnabled;

        private int startSpeed;
        private int maxSpeed;
        private int speedIncrease;
        private int gameBlocksShowTime;

        public GameController(Form gameBoard,
            LeaderboardController leaderboardManager,
            int gameBoardSize, int startSpeed,
            int maxSpeed, int speedIncrease,
            int maxBlocksCount)
        {
            // Disables the block selection
            this.blockSelectionIsEnabled = false;

            // Sets initial values for the game
            this.leaderboardManager = leaderboardManager;
            this.RequiredCurrentLevelBlocks = new List<string>();
            this.SelectedBlocks = new List<string>();
            this.CurrentPlayerScore = 0;
            this.GameBoardSize = gameBoardSize;

            this.requredCurrentLevelBlocks = Constants.StartBlocksCount;
            this.gameBoard = gameBoard;
            this.startSpeed = startSpeed;
            this.maxSpeed = maxSpeed;
            this.speedIncrease = speedIncrease;
            this.maxBlocksCount = maxBlocksCount;

            this.gameBlocksShowTime = this.startSpeed;
        }



        // List containg the required blocks for each level
        public List<string> RequiredCurrentLevelBlocks { get; private set; }

        // List containg the player's selected blocks for each round
        public List<string> SelectedBlocks { get; private set; }

        // The current player's score
        public int CurrentPlayerScore { get; private set; }

        // The size of the game board
        public int GameBoardSize { get; private set; }



        // Starts a new game
        public void StartGame()
        {
            // Set the player score to 0
            this.CurrentPlayerScore = 0;

            // Set the initial blocks count 
            this.requredCurrentLevelBlocks = Constants.StartBlocksCount;

            // Set the initial game blocks show speed
            this.gameBlocksShowTime = this.startSpeed;

            // Start a new round
            this.StartNewRound();
        }

        // Starts a new round of the game
        public void StartNewRound()
        {
            // Empty the selected blocks and the required blocks for the current level
            this.SelectedBlocks = new List<string>();
            this.RequiredCurrentLevelBlocks = new List<string>();

            // Disable block selection
            this.blockSelectionIsEnabled = false;

            // Clear blocks
            this.ClearBlocks();

            // Update player score
            this.UpdatePlayerScore();

            // Create a short delay
            Task.Delay(Constants.GeneratingBlocksDelay).ContinueWith(firstTask =>
            {
                // Generate the required blocks for the current level
                this.GenerateCurrentLevelBlocks();

                // Show the required blocks for the current level
                this.ShowCurrentLevelBlocks();

                // Create a short delay
                Task.Delay(this.gameBlocksShowTime).ContinueWith(secondTask =>
                {
                    // Clear the block
                    this.ClearBlocks();

                    // Enable block selection
                    blockSelectionIsEnabled = true;
                });
            });
        }

        // Hides colored blocks - make all blocks in gray coloring
        public void ClearBlocks()
        {
            // Get the controls of the current game board
            ControlCollection gameBoardControls = this.gameBoard.Controls.Find("GameBoard", true).First().Controls;

            // Go through each control
            foreach (Control control in gameBoardControls)
            {
                // Get the tag of the current control
                string controlTag = control.Tag.ToString();

                // If the control name is GameBlock
                if (controlTag == "GameBlock")
                {
                    // Change it's color to light gray
                    control.BackColor = Color.LightGray;
                }
            }
        }

        // Updates player score displayed on the screen
        public void UpdatePlayerScore()
        {
            // Get the player's score control
            Control scoreBoard = this.gameBoard.Controls.Find("ScoreValue", true).First();

            // Change the text to the player's score
            scoreBoard.Text = this.CurrentPlayerScore.ToString();
        }

        // Generates random blocks for the current level
        public void GenerateCurrentLevelBlocks()
        {
            // While the current level blocks list count hasn't reached the required for the current level
            while (this.RequiredCurrentLevelBlocks.Count != this.requredCurrentLevelBlocks)
            {
                // Create a random object for random numbers
                Random randomNumber = new Random();

                // Create random number for the block row
                int currentBlockRow = randomNumber.Next(1, this.GameBoardSize + 1);

                // Create random number for the block column
                int currentLevelBlockCol = randomNumber.Next(1, this.GameBoardSize + 1);

                // Create the block name
                string currentBlockName = $"panel{currentBlockRow}{currentLevelBlockCol}";

                // If the current block hasn't been added already
                if (!this.RequiredCurrentLevelBlocks.Contains(currentBlockName))
                {
                    // Add the current block name to the list
                    this.RequiredCurrentLevelBlocks.Add(currentBlockName);
                }
            }
        }

        // Shows current level blocks - blue ones
        public void ShowCurrentLevelBlocks()
        {
            // Go through each block in the current level blocks
            foreach (string block in this.RequiredCurrentLevelBlocks)
            {
                // Get the current level block's control
                Control currentBlockControl = this.gameBoard.Controls.Find(block, true).FirstOrDefault();

                // If the control is not null
                if (currentBlockControl != null)
                {
                    // Change the color of the block to light blue
                    currentBlockControl.BackColor = Color.LightBlue;
                }
            }
        }

        // Handles the event of clicking a game block
        public void HandleGameBlockClick(Control clickedGameBlock)
        {
            // If the player can select blocks, the selected blocks count is less than the requered count and the selected blocks don't already contain the clicked block
            if (this.blockSelectionIsEnabled && (this.SelectedBlocks.Count != this.requredCurrentLevelBlocks) && !this.SelectedBlocks.Contains(clickedGameBlock.Name))
            {
                // Change the clicked game block color
                clickedGameBlock.BackColor = Color.LightBlue;

                // Add the clicked block to the selected blocks list
                this.SelectedBlocks.Add(clickedGameBlock.Name);

                // If the selected blocks count has reached the required for the level
                if (this.SelectedBlocks.Count == this.requredCurrentLevelBlocks)
                {
                    // Disable block selection
                    this.blockSelectionIsEnabled = false;

                    // Create a short delay
                    Task.Delay(Constants.CheckSelectedBoxesDelay).ContinueWith(t =>
                    {
                        // Check if the selected block are correct
                        bool correctBlocksAreSelected = this.CorrectBlocksAreSelected();

                        // If they are correct
                        if (correctBlocksAreSelected)
                        {
                            // Handle correct blocks selection
                            CorrectBlocksSelectedHandler();
                        }
                        else
                        {
                            // Handle wrong blocks selection
                            WrongBlocksSelectedHandler();
                        }
                    });
                }
            }
        }

        // Check if the selected blocks are the correct ones
        public bool CorrectBlocksAreSelected()
        {
            // Goes through each block for the current level
            bool correctBlocksSelected = true;
            foreach (var block in this.RequiredCurrentLevelBlocks)
            {
                // If the selected blocks don't contain it the player has made a mistake
                if (!this.SelectedBlocks.Contains(block))
                {
                    correctBlocksSelected = false;
                    break;
                }
            }

            return correctBlocksSelected;
        }

        // Handles the situation when the correct blocks are selected
        public void CorrectBlocksSelectedHandler()
        {
            // Colors the selected blocks in green
            this.ColorBlocks(this.SelectedBlocks, Color.LightGreen);

            // Increases the player score with one
            this.CurrentPlayerScore += 1;

            // Checks if the game difficulty should be increased 
            if (this.CurrentPlayerScore % Constants.SpeedIncreaseRoundsCount == 0)
            {
                // Increases the blocks count
                this.requredCurrentLevelBlocks++;

                // Checks if the max level blocks count is reached for the current level
                this.requredCurrentLevelBlocks = Math.Min(this.requredCurrentLevelBlocks, this.maxBlocksCount);


                // Decreases the game blocks show time with the specific value
                this.gameBlocksShowTime -= this.speedIncrease;

                // Checks if the speed has reached it's maximum for the current level
                this.gameBlocksShowTime = Math.Max(this.gameBlocksShowTime, this.maxSpeed);
            }

            // Delays the game for a few moments
            Task.Delay(Constants.StartNewRoundDelay).ContinueWith(ts =>
            {
                // Starts a new game round 
                this.StartNewRound();
            });
        }

        // Handles the situation when the wrong blocks are selected
        private void WrongBlocksSelectedHandler()
        {
            // Colors the current level block in dark red
            this.ColorBlocks(this.RequiredCurrentLevelBlocks, Color.DarkRed);

            // Colors the selected block in light red
            this.ColorBlocks(this.SelectedBlocks, Color.IndianRed);

            // Gets the start button control
            Control startButton = this.gameBoard.Controls.Find("StartButton", true).First();

            // Changes it's text and shows it
            startButton.Text = "New Game";
            startButton.Visible = true;

            // Gets the return home button control and shows it
            Control returnHomeButton = this.gameBoard.Controls.Find("ReturnHomeButton", true).First();
            returnHomeButton.Visible = true;

            // Checks if the user can enter the leaderboard with his score
            this.CheckLeaderboard();
        }


        // Colors the passed blocks with the passed color
        public void ColorBlocks(List<string> blocks, Color color)
        {
            // Go through each block on the game board
            foreach (var block in blocks)
            {
                // Get the current block control 
                Control currentBlockControl = this.gameBoard.Controls.Find(block, true).First();

                // If the current block control is not null
                if (currentBlockControl != null)
                {
                    // Change it's color to the passed one
                    currentBlockControl.BackColor = color;
                }
            }
        }

        // Checks if the user can enter the leaderboard with his score
        public async void CheckLeaderboard()
        {
            // Get the leaderboard data from the database
            List<LeaderboardData> leaderboardData = await this.leaderboardManager.GetLeaderboard();

            // If the leaderboard has less than 10 records or has more than 10 and someone has smaller score than the current one
            if ((leaderboardData.Count < 10) || (leaderboardData.Count >= 10 && leaderboardData.Any(u => u.Score < this.CurrentPlayerScore)))
            {
                // Create leaderboard prompt form
                LeaderboardPrompt leaderboardPrompt = new LeaderboardPrompt(this.CurrentPlayerScore, this.leaderboardManager);

                // Show it in dialog window
                leaderboardPrompt.ShowDialog();
            }
        }
    }
}
