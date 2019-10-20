using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace VSP_4153_MyProject
{
    public class GameManager
    {
        private int currentLevelBlocksCount;
        private int gameBlocksShowTime;
        private bool blockSelectionIsEnabled;
        private Form gameBoard;

        public GameManager(Form gameBoard, int gameBoardSize)
        {
            this.blockSelectionIsEnabled = false;

            this.CurrentLevelBlocks = new List<string>();
            this.SelectedBlocks = new List<string>();
            this.CurrentPlayerScore = 0;
            this.GameBoardSize = gameBoardSize;

            this.currentLevelBlocksCount = 3;
            this.gameBoard = gameBoard;
            this.gameBlocksShowTime = 2000;
        }

        public List<string> CurrentLevelBlocks { get; private set; }

        public List<string> SelectedBlocks { get; private set; }

        public int CurrentPlayerScore { get; private set; }

        public int GameBoardSize { get; private set; }

        // Updates player score
        public void UpdatePlayerScore(int newScore)
        {
            this.CurrentPlayerScore = newScore;
            this.gameBoard.Controls.Find("ScoreValue", true).First().Text = newScore.ToString();
        }

        // Starts new game
        public void StartGame()
        {
            this.currentLevelBlocksCount = 3;
            this.gameBlocksShowTime = 2000;

            this.StartNewRound();
        }

        // Start new round of the game
        public void StartNewRound()
        {
            this.SelectedBlocks = new List<string>();
            this.CurrentLevelBlocks = new List<string>();

            this.blockSelectionIsEnabled = false;

            this.ClearBlocks();

            Task.Delay(1000).ContinueWith(t =>
            {
                this.GenerateCurrentLevelBlocks();
                this.ShowCurrentLevelBlocks();
            });

            Task.Delay(this.gameBlocksShowTime).ContinueWith(t =>
            {
                this.ClearBlocks();
                blockSelectionIsEnabled = true;
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
            if (this.blockSelectionIsEnabled)
            {
                if (this.SelectedBlocks.Count != this.currentLevelBlocksCount)
                {
                    clickedGameBlock.BackColor = Color.LightBlue;
                    this.SelectedBlocks.Add(clickedGameBlock.Name);

                    if (this.SelectedBlocks.Count == this.currentLevelBlocksCount)
                    {
                        this.blockSelectionIsEnabled = false;

                        Task.Delay(200).ContinueWith(t =>
                        {
                            bool correctBlocksAreSelected = this.CorrectBlocksAreSelected();
                            if (correctBlocksAreSelected)
                            {
                                ColorBlocks(this.SelectedBlocks, Color.LightGreen);

                                Task.Delay(300).ContinueWith(ts =>
                                {
                                    StartNewRound();
                                });

                                UpdatePlayerScore(this.CurrentPlayerScore + 1);
                                if(this.CurrentPlayerScore % 3 == 0)
                                {
                                    this.currentLevelBlocksCount++;

                                    this.gameBlocksShowTime -= 50;
                                }

                            }
                            else
                            {
                                this.ColorBlocks(this.CurrentLevelBlocks, Color.DarkRed);
                                this.ColorBlocks(this.SelectedBlocks, Color.IndianRed);

                                Control startButton = this.gameBoard.Controls.Find("StartButton", true).First();
                                startButton.Visible = true;
                                startButton.Text = "New Game";
                            }
                        });
                    }
                }
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
