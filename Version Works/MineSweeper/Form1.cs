using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


/**
 * Minesweeper program ('Bomb Finder') for AC22005 Assignment 1 - C# Game
 * Written by Ross Mitchell (170008410) & Patrick Turton-Smith (170012743)
 * 
 * References:
 * [1] Bomb clip art for bomb squares & program icon from https://openclipart.org/detail/252171/black-cartoon-bomb, used under public domain
 * [2] Flag clip art for flagged squares from https://openclipart.org/detail/255282/racing-flag-red, used under public domain
 * [3] Background music (Memories, Epic & Extreme Action) from https://www.bensound.com/, used under Free Creative Commons Licence
 * [4] Explosion sound effect (on finding a bomb) from https://freesound.org/people/Iwiploppenisse/sounds/156031/, used under Creative Commons Attribution Licence
 * [5] Victory sound effect (on winning the game) from https://freesound.org/people/FunWithSound/sounds/369252/, used under Creative Commons Noncommercial Attribution Licence
 */

namespace MineSweeper
{
    public partial class MineSweeper : Form
    {
        // Code placed/controlled Form objects
        Button[,] btn;  // 2D Array for grid of buttons
        Random r = new Random(); // Random number for placement of bombs on grid
        Label leaderboardTitle; // Label for leaderboard
        Label[] leaderboardPlaces = new Label[5]; // Array of labels for the 5 top scorers
        
        // Program wide fields
        int bombs; // Number of bombs on the grid
        int gameTime; // Number of seconds since the current game was started
        int correctFlags; // Number of correctly placed flags
        int wrongFlags; // Number of incorrectly placed flags
        int size; // Size of the grid
        string[] leaderboardNames = new string[5]; // Array of 5 names for the leaderboard
        int[] leaderboardTimes = new int[5]; // Array of 5 scores for the leaderboard


        // SoundPlayers for the different background music/sound effects used in the game
        SoundPlayer bckgndEasy = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-memories.wav"); // Ref.[3]
        SoundPlayer bckgndMed = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-epic.wav"); // Ref.[3]
        SoundPlayer bckgndHard = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-extremeaction.wav"); // Ref.[3]
        SoundPlayer clipWin = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\Victory.wav"); // Ref.[5]
        SoundPlayer clipLose = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\Explosion.wav"); // Ref.[4]


        // Default constructor for MineSweeper class. Default game difficulty is easy (10x10 grid, 10 bombs)
        // Loads leaderboard from file before starting the game
        public MineSweeper()
        {
            size = 10;
            bombs = 10;
            loadLeaderboard();
            runGame();
        }
        

        // Method for initialising a game of Bomb Finder. Generates the grid of buttons, randomly places a pre-determined number of bombs onto the grid and displays the previously loaded leaderboard on the form.
        void runGame()
        {
            // Select correct background music for difficulty chosen
            if (size == 10) // Difficulty easy
            {
                bckgndEasy.Play();
            }
            else if (size == 15) // Difficulty medium
            {
                bckgndMed.Play();
            }
            else // Difficulty hard
            {
                bckgndHard.Play();
            }

            InitializeComponent();

            // Reset the following game variables
            gameTime = 0;
            correctFlags = 0;
            wrongFlags = 0;

            // Generate and display the grid of buttons on which the game is to be played
            btn = new Button[size, size]; // Generate correct size of 2D array for difficulty
            for (int x = 0; x < btn.GetLength(0); x++) // Loops for x and y
            {
                for (int y = 0; y < btn.GetLength(1); y++)
                {
                    btn[x, y] = new Button();
                    btn[x, y].FlatStyle = FlatStyle.Flat;
                    btn[x, y].FlatAppearance.BorderSize = 1;
                    btn[x, y].FlatAppearance.BorderColor = Color.Black;
                    btn[x, y].SetBounds(255 + (35 * x), 27 + (35 * y), 35, 35);
                    btn[x, y].BackColor = Color.White;
                    btn[x, y].Font = new Font("Comic Sans MS", 12.0F, btn[x, y].Font.Style, btn[x, y].Font.Unit);
                    btn[x, y].ForeColor = Color.White;
                    btn[x, y].MouseDown += new MouseEventHandler(this.btnEvent_MouseDown);
                    Controls.Add(btn[x, y]);
                }

            }

            // Generate and display leaderboard title
            leaderboardTitle = new Label();
            leaderboardTitle.Name = "LeaderboardTitle";
            leaderboardTitle.Text = "Best Times";
            leaderboardTitle.Font = new Font("Comic Sans MS", 16.0F);
            leaderboardTitle.TextAlign = ContentAlignment.MiddleCenter;
            leaderboardTitle.SetBounds(5, 165, 245, 35);
            Controls.Add(leaderboardTitle);

            // Generate and display each place in leaderboard
            leaderboardPlaces[0] = createLeaderboardLabels(leaderboardTitle, 1);
            Controls.Add(leaderboardPlaces[0]);
            for (int i = 1; i < 5; i++)
            {
                leaderboardPlaces[i] = createLeaderboardLabels(leaderboardPlaces[i - 1], i + 1);
                Controls.Add(leaderboardPlaces[i]);
            }

            // Randomly place bombs on grid
            int bombsPlaced = 0;
            int randX = 0;
            int randY = 0;
            while (bombsPlaced != bombs) // Repeat until there are correct number of bombs on the grid
            {
                randX = r.Next(btn.GetLength(0));
                randY = r.Next(btn.GetLength(1));
                if (btn[randX, randY].Name != "Bomb")
                {
                    btn[randX, randY].Name = "Bomb";
                    bombsPlaced++;
                }
            }

            numbers(); // Assign the appropriate numbers to rest of grid

            timer1.Start(); // Start the timer for the game
        }

        // Create the labels for each place on the leaderboard
        Label createLeaderboardLabels(Label prevLbl, int number)
        {
            Label newLabel = new Label();
            newLabel.Name = "Leaderboard " + Convert.ToString(number);
            string lblTxt = String.Format(@"{0}. {1} - {2}secs", Convert.ToString(number), leaderboardNames[number - 1], Convert.ToString(leaderboardTimes[number - 1]));
            newLabel.Text = lblTxt;
            newLabel.Font = new Font("Comic Sans MS", 12.0F);
            newLabel.TextAlign = ContentAlignment.MiddleLeft;
            newLabel.AutoSize = true;
            newLabel.Top = prevLbl.Bottom + 5;
            newLabel.Left = prevLbl.Left;
            return newLabel;
        }

        // Method to traverse the grid and add the numbers to each square that has bombs nearby, and setting a zero to each square that does not have any adjacent bombs 
        void numbers()
        {
            int num = 0;
            String value = "";
            // For every button in the grid
            for (int x = 0; x < btn.GetLength(0); x++)
            {
                for (int y = 0; y < btn.GetLength(1); y++)
                {
                    num = 0;
                    value = "";
                    if (btn[x, y].Name != "Bomb") // If button is not already a bomb itself
                    {
                        if (y == 0 || y == btn.GetLength(1) - 1 || x == btn.GetLength(0) - 1 || x == 0) // If button is on one of the outer edges of the grid
                        {
                            if (y == 0 && x == 0) // Top left corner
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x + 1, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }

                            }
                            else if (y == 0 && x == btn.GetLength(0) - 1) // Top right corner
                            {
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }

                            }
                            else if (x == 0 && y == btn.GetLength(1) - 1) // Bottom left corner
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x + 1, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }

                            }
                            else if (x == btn.GetLength(0) - 1 && y == btn.GetLength(1) - 1) // Bottom right corner
                            {
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                            }
                            else if (y == 0) // Left edge
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x + 1, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                            }
                            else if (x == 0) // Top edge
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x + 1, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x + 1, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                            }
                            else if (y == btn.GetLength(1) - 1) // Right edge
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x + 1, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                            }
                            else if (x == btn.GetLength(0) - 1) // Bottom edge
                            {
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y + 1].Name == "Bomb")
                                {
                                    num++;
                                }
                                if (btn[x - 1, y - 1].Name == "Bomb")
                                {
                                    num++;
                                }
                            }
                            // Set button name to be that of the number of bombs around it
                            value = Convert.ToString(num);
                            btn[x, y].Name = value;

                            num = 0;
                            value = "";
                        }
                        else // Else if anywhere inside the grid (not on the outer edges)
                        {
                            if (btn[x + 1, y].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x - 1, y].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x, y + 1].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x, y - 1].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x - 1, y + 1].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x + 1, y - 1].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x - 1, y - 1].Name == "Bomb")
                            {
                                num++;
                            }
                            if (btn[x + 1, y + 1].Name == "Bomb")
                            {
                                num++;
                            }
                            // Set button name to be that of the number of bombs around it
                            value = Convert.ToString(num);
                            btn[x, y].Name = value;

                            num = 0;
                            value = "";
                        }
                    }
                }
            }
        }
        
        // Recursive method for uncovering surrounding zero squares - and an adjacent layer of numbered squares
        // Receives the x & y coords, and layer (which records whether the method has encountered any non-zero squares) as parameters
        int uncoverZero(int x, int y, int layer)
        {
            if ((x < 0 || x >= btn.GetLength(0) || y < 0 || y >= btn.GetLength(1)) || btn[x, y].BackColor == Color.ForestGreen) // If coord is outside the grid, or if the button has already been uncovered
            {
                return 0;
            }
            else // Else button is inside the grid and has not yet been revealed
            {
                btn[x, y].BackColor = Color.ForestGreen;
                btn[x, y].Text = btn[x, y].Name;
                if (btn[x, y].Name != "0")
                {
                    return 0;
                }
                return uncoverZero(x - 1, y, layer) + uncoverZero(x + 1, y, layer) + uncoverZero(x, y + 1, layer) + uncoverZero(x, y - 1, layer);
            }
        }
        
        // Event handler for the grid of buttons. Differentiates between a left click or right click and performs different actions as appropriate
        // Right clicking a square/button marks it as a potential bomb location (flag). If all the bombs have been correctly flagged (and no false flags remain) then this will win the game
        // Left clicking a square/button uncovers the square, revealing either zero (in which case others around it will be uncovered), a number, or a bomb - which will lose the game and uncover the rest of the bombs
        void btnEvent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) { // On right click
                if (((Button)sender).BackgroundImage == null && ((Button)sender).BackColor == Color.White) { // If button not already flagged, or has not already been uncovered
                    ((Button)sender).BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "flag.png"); // Ref.[2] Add flag image
                    if (((Button)sender).Name == "Bomb") // If button hides a bomb, then it is a correct flag
                    {
                        correctFlags++;
                    } else // If not then it is a wrong one (false flag)
                    {
                        wrongFlags++;
                    }

                }
                else // If button has already been flagged or has already been uncovered
                {
                    if (((Button)sender).BackColor != Color.Green) // If button not already uncovered, then it has already been flagged
                    {
                        ((Button)sender).BackgroundImage = null; // Remove flag image
                        if (((Button)sender).Name == "Bomb") // If button is a bomb, then it was a correct flag
                        {
                            correctFlags--;
                        }
                        else // If it wasn't, then it was a false flag
                        {
                            if (wrongFlags > 0)
                            {
                                wrongFlags--;
                            }
                        }
                    }
                }
            }
            else // On left click
            {
                if (((Button)sender).Name == "Bomb") // If button was a bomb
                {
                    // Display bomb clip art and change colour
                    ((Button)sender).BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "bomb.png"); // Ref.[1]
                    ((Button)sender).BackColor = Color.Red;

                    // Traverse grid and uncover the other bombs
                    for (int x = 0; x < btn.GetLength(0); x++)
                    {
                        for (int y = 0; y < btn.GetLength(1); y++)
                        {
                            if(btn[x,y].Name == "Bomb")
                            {
                                btn[x, y].BackColor = Color.Red;
                                btn[x, y].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "bomb.png"); // Ref.[1]
                            }
                        }
                    }
                    clipLose.Play(); // Play losing sound effect
                    timer1.Stop(); // Stop timer
                    MessageBox.Show("Game Over!" + Environment.NewLine + "You survived for " + Convert.ToString(gameTime) + " seconds", "Game Over!"); // Tell user they've lost
                    
                    // Clear the form and reset the game
                    Controls.Clear();
                    runGame();
                }
                else if (((Button)sender).Name == "0") // If button was a zero, then determine it's coordinates and uncover surrounding zeros
                {
                    int x = (((Button)sender).Left - 255) / 35;
                    int y = (((Button)sender).Top - 25) / 35;
                    ((Button)sender).BackgroundImage = null;
                    uncoverZero(x, y, 0);
                }
                else // Otherwise, uncover the button, turn it green and display its number
                {
                    ((Button)sender).BackgroundImage = null;
                    ((Button)sender).BackColor = Color.Green;
                    ((Button)sender).Text = ((Button)sender).Name;

                }
            }

            if (correctFlags == bombs && wrongFlags == 0) // If the user has correctly flagged all the bombs, and made no false flags, then the game is won
            {
                timer1.Stop(); // Stop timer
                clipWin.Play(); // Play victory music
                DialogResult gameWon = MessageBox.Show("You won!" + Environment.NewLine + "You found all the bombs in " + Convert.ToString(gameTime) + " seconds!" + Environment.NewLine + "Do you want to add your score to the leaderboard?", "Winner!", MessageBoxButtons.YesNo); // Tell player and give their score, ask if they want to be added to leaderboard
                if (gameWon == DialogResult.Yes) // If yes to leaderboard then add them
                {
                    addToLeaderboard();
                }
                
                // Clear the form and reset the game
                Controls.Clear();
                runGame();
            }
        }

        // Find if new score is good enough for leaderboard and add it if it is
        private void addToLeaderboard()
        {
            int newPlace = 5;
            bool foundPlace = false;
            for (int i = 4; i >= 0; i--) // Traverse leaderboard times and see if the current game's time beats any of the others
            {
                if (gameTime < leaderboardTimes[i])
                {
                    newPlace = i;
                    foundPlace = true;
                }
            }
            if (foundPlace == false || newPlace == 5) // If time does not beat any existing on the leaderboard, tell the user
            {
                MessageBox.Show("You were not good enough to get onto the leaderboard.", "Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Else move the scores below the new one down a place, removing the current 5th place player at the same time
            {
                for (int i = 4; i > newPlace; i--) // Move scores down
                {
                    leaderboardNames[i] = leaderboardNames[i - 1];
                    leaderboardTimes[i] = leaderboardTimes[i - 1];
                }
                string difficulty; // Add suffix for what difficulty the score was achieved on
                if (size == 10)
                {
                    difficulty = "(Easy)";
                }
                else if (size == 15)
                {
                    difficulty = "(Medium)";
                }
                else
                {
                    difficulty = "(Hard)";
                }
                string playerName = Microsoft.VisualBasic.Interaction.InputBox("Enter name for leaderboard", "Leaderboard", "NoName"); // Get players name
                leaderboardNames[newPlace] = playerName + " " + difficulty; // Add players name & difficulty to board
                leaderboardTimes[newPlace] = gameTime; // Add players score to same place on board
                saveLeaderboard(); // Save leaderboard to the file
                updateLeaderboard(); // And finally update the leaderboard displayed on the form
            }

        }

        // Method for updating the form objects that display the leaderboard
        private void updateLeaderboard()
        {
            for (int i = 0; i < 5; i++)
            {
                string lblTxt = String.Format(@"{0}. {1} - {2}secs", Convert.ToString(i + 1), leaderboardNames[i], Convert.ToString(leaderboardTimes[i]));
                leaderboardPlaces[i].Text = lblTxt;
            }
        }

        // Load leaderboard from file, called when the program first starts, and places it into the arrays of names and scores that store the leaderboard when the program is running
        private void loadLeaderboard()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "Leaderboard.txt");
            StreamReader openLeaderboard = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "Leaderboard.txt");
            string read = null;
            int i = 0;
            while ((read = openLeaderboard.ReadLine()) != null)
            {
                string[] splitLine = read.Split('-');
                leaderboardNames[i] = splitLine[0];
                leaderboardTimes[i] = Convert.ToInt32(splitLine[1]);
                i++;
            }
            openLeaderboard.Close();
        }

        // Save current leaderboard to file, called every time the leaderboard is updated to ensure that the file is always up to date
        private void saveLeaderboard()
        {
            StreamWriter saveLeaderboard = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Leaderboard.txt");
            for (int i = 0; i < 5; i++)
            {
                saveLeaderboard.WriteLine(leaderboardNames[i] + "-" + leaderboardTimes[i]);
            }
            saveLeaderboard.Close();
        }

        private void MineSweeper_Load(object sender, EventArgs e)  //REQUIRED
        {
                        
        }

        private void NewGameDropDown_Click(object sender, EventArgs e)
        {
            
        }

        // Generates a message box to tell the user how to play the game
        private void RulesDropDown_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Welcome to Bomb Finder!" + Environment.NewLine + "The aim of the game is to safely flag all of the bombs on the grid without setting any off." + Environment.NewLine + "Use left click on squares to reveal what is underneath them. The numbers show how many bombs are around the square." + Environment.NewLine + "Right click to flag the bombs." + Environment.NewLine + "The game is won when you have correctly flagged all of the bombs, and you cannot win with any false flags." + Environment.NewLine + "Good Luck! :)");
            timer1.Start();
        }

        // Closes the program
        private void ExitDropDown_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Starts a new game with easy difficulty. Stops current game timer, clears the form, sets the grid size & number of bombs before calling runGame method to start a new game.
        private void easyGameMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls.Clear();
            size = 10;
            bombs = 10;
            runGame();
        }

        // Starts a new game with medium difficulty. Stops current game timer, clears the form, sets the grid size & number of bombs before calling runGame method to start a new game.
        private void mediumGameMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls.Clear();
            size = 15;
            bombs = 40;
            runGame();
        }

        // Starts a new game with hard difficulty. Stops current game timer, clears the form, sets the grid size & number of bombs before calling runGame method to start a new game.
        private void hardGameMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls.Clear();
            size = 25;
            bombs = 80;
            runGame();
        }

        // Method for handling a tick event from the game's timer, increments game timer by 1 for every tick (every 60 seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            gameTime++;
            LblTimer.Text = "Time elapsed: " + Convert.ToString(gameTime) + " sec";
        }

        // Method for displaying the About dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Bomb Finder in C# by Ross Mitchell & Patrick Turton-Smith" + Environment.NewLine + "Latest release: 08/02/2019", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Start();
        }
    }
}
