﻿using System;
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
    public class GameManager
    {
        private LeaderboardManager leaderboardManager;
        private Form gameBoard;
        private int currentLevelBlocksCount;
        private int maxBlocksCount;
        private bool blockSelectionIsEnabled;

        private int startSpeed;
        private int maxSpeed;
        private int speedIncrease;
        private int gameBlocksShowTime;

        public GameManager(Form gameBoard,
            LeaderboardManager leaderboardManager,
            int gameBoardSize, int startSpeed,
            int maxSpeed, int speedIncrease,
            int maxBlocksCount)
        {
            this.blockSelectionIsEnabled = false;

            this.leaderboardManager = leaderboardManager;
            this.CurrentLevelBlocks = new List<string>();
            this.SelectedBlocks = new List<string>();
            this.CurrentPlayerScore = 0;
            this.GameBoardSize = gameBoardSize;

            this.currentLevelBlocksCount = Constants.StartBlocksCount;
            this.gameBoard = gameBoard;
            this.startSpeed = startSpeed;
            this.maxSpeed = maxSpeed;
            this.speedIncrease = speedIncrease;
            this.maxBlocksCount = maxBlocksCount;

            this.gameBlocksShowTime = this.startSpeed;
        }

        public List<string> CurrentLevelBlocks { get; private set; }

        public List<string> SelectedBlocks { get; private set; }

        public int CurrentPlayerScore { get; private set; }

        public int GameBoardSize { get; private set; }

        // Updates player score
        public void UpdatePlayerScore()
        {
            Control scoreBoard = this.gameBoard.Controls.Find("ScoreValue", true).First();
            scoreBoard.Text = this.CurrentPlayerScore.ToString();
        }

        // Starts new game
        public void StartGame()
        {
            this.currentLevelBlocksCount = Constants.StartBlocksCount;
            this.gameBlocksShowTime = this.startSpeed;

            this.StartNewRound();
        }

        // Start new round of the game
        public void StartNewRound()
        {
            this.SelectedBlocks = new List<string>();
            this.CurrentLevelBlocks = new List<string>();

            this.blockSelectionIsEnabled = false;

            this.ClearBlocks();
            this.UpdatePlayerScore();

            Task.Delay(Constants.GeneratingBlocksDelay).ContinueWith(firstTask =>
            {
                this.GenerateCurrentLevelBlocks();
                this.ShowCurrentLevelBlocks();

                Task.Delay(this.gameBlocksShowTime).ContinueWith(secondTask =>
                {
                    this.ClearBlocks();
                    blockSelectionIsEnabled = true;
                });
            });
        }

        // Hides colored blocks - make all gray
        public void ClearBlocks()
        {
            ControlCollection gameBlocks = this.gameBoard.Controls.Find("GameBoard", true).First().Controls;
            foreach (Control control in gameBlocks)
            {
                if (control.Tag.ToString() == "GameBlock")
                {
                    control.BackColor = Color.LightGray;
                }
            }
        }

        // Generates random blocks for the current level
        public void GenerateCurrentLevelBlocks()
        {
            while (this.CurrentLevelBlocks.Count != this.currentLevelBlocksCount)
            {
                Random randomNumber = new Random();

                int currentBlockRow = randomNumber.Next(1, this.GameBoardSize + 1);
                int currentLevelBlockCol = randomNumber.Next(1, this.GameBoardSize + 1);

                string currentBlockName = $"panel{currentBlockRow}{currentLevelBlockCol}";

                if (!this.CurrentLevelBlocks.Contains(currentBlockName))
                {
                    this.CurrentLevelBlocks.Add(currentBlockName);
                }
            }
        }

        // Shows current level blocks - blue ones
        public void ShowCurrentLevelBlocks()
        {
            foreach (string block in this.CurrentLevelBlocks)
            {
                Control currentBlockControl = this.gameBoard.Controls.Find(block, true).FirstOrDefault();
                if (currentBlockControl != null)
                {
                    currentBlockControl.BackColor = Color.LightBlue;
                }
            }
        }

        // Handles the event of clicking a game block
        public void HandleGameBlockClick(Control clickedGameBlock)
        {
            if (this.blockSelectionIsEnabled && (this.SelectedBlocks.Count != this.currentLevelBlocksCount))
            {
                clickedGameBlock.BackColor = Color.LightBlue;
                this.SelectedBlocks.Add(clickedGameBlock.Name);

                if (this.SelectedBlocks.Count == this.currentLevelBlocksCount)
                {
                    this.blockSelectionIsEnabled = false;

                    Task.Delay(Constants.CheckSelectedBoxesDelay).ContinueWith(t =>
                    {
                        bool correctBlocksAreSelected = this.CorrectBlocksAreSelected();
                        if (correctBlocksAreSelected)
                        {
                            this.ColorBlocks(this.SelectedBlocks, Color.LightGreen);

                            this.CurrentPlayerScore += 1;

                            if (this.CurrentPlayerScore % Constants.SpeedIncreaseRoundsCount == 0)
                            {
                                this.currentLevelBlocksCount++;
                                this.currentLevelBlocksCount = Math.Min(this.currentLevelBlocksCount, this.maxBlocksCount);

                                this.gameBlocksShowTime -= this.speedIncrease;
                                this.gameBlocksShowTime = Math.Max(this.gameBlocksShowTime, this.maxSpeed);
                            }

                            Task.Delay(Constants.StartNewRoundDelay).ContinueWith(ts =>
                            {
                                this.StartNewRound();
                            });
                        }
                        else
                        {
                            this.ColorBlocks(this.CurrentLevelBlocks, Color.DarkRed);
                            this.ColorBlocks(this.SelectedBlocks, Color.IndianRed);

                            Control startButton = this.gameBoard.Controls.Find("StartButton", true).First();
                            startButton.Visible = true;
                            startButton.Text = "New Game";

                            Control returnHomeButton = this.gameBoard.Controls.Find("ReturnHomeButton", true).First();
                            returnHomeButton.Visible = true;

                            this.LeaderboardAction();
                        }
                    });
                }
            }
        }

        public void LeaderboardAction()
        {
            Leaderboard leaderboard = this.leaderboardManager.GetLeaderboard();
            if (leaderboard.Data.Any(u => u.Score < this.CurrentPlayerScore))
            {
                // todo 
                // dialog show please enter name you are in top 10
                // if name is entered remove last
                // add this to the db
                // if cancel is clicked continue
            }
        }


        // Check if the selected blocks are the correct ones
        public bool CorrectBlocksAreSelected()
        {
            bool correctBlocksSelected = true;
            foreach (var block in this.CurrentLevelBlocks)
            {
                if (!this.SelectedBlocks.Contains(block))
                {
                    correctBlocksSelected = false;
                    break;
                }
            }

            return correctBlocksSelected;
        }

        // Colors the passed blocks with the passed color
        public void ColorBlocks(List<string> blocks, Color color)
        {
            foreach (var block in blocks)
            {
                Control currentBlockControl = this.gameBoard.Controls.Find(block, true).First();
                if (currentBlockControl != null)
                {
                    currentBlockControl.BackColor = color;
                }
            }
        }
    }
}
