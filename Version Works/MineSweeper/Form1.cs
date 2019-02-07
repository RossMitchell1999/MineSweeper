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


/**
 * Minesweeper program ('Bomb Finder') for AC22005 Assignment 1
 * Written by Ross Mitchell & Patrick Turton-Smith
 * References:
 * Bomb clip art for bomb squares & program icon from https://openclipart.org/detail/252171/black-cartoon-bomb, used under public domain
 * Flag clip art for flagged squares from https://openclipart.org/detail/255282/racing-flag-red, used under public domain
 * Background music (Memories) from https://www.bensound.com/, used under Free Creative Commons Licence
 * 
 */

namespace MineSweeper
{
    public partial class MineSweeper : Form
    {

        Button[,] btn;
        Random r = new Random();
        Label timer;

        int bombs;
        int gameTime;
        int correctFlags;
        int wrongFlags;
        int size;

        SoundPlayer se = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-memories.wav");
        SoundPlayer sm = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-epic.wav");
        SoundPlayer sh = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-extremeaction.wav");
        SoundPlayer sw = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\Victory.wav");

        public MineSweeper()
        {
            size = 10;
            bombs = 10;
            runGame();
            SoundPlayer sp = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\bensound-memories.wav");
            sp.Play();
        }

        void runGame()
        {
            if (size == 10)
            {
                se.Play();
            }
            else if(size == 15){
                sm.Play();
            }
            else
            {
                sh.Play();
            }
            InitializeComponent();
           
            gameTime = 0;
            correctFlags = 0;
            wrongFlags = 0;
            btn = new Button[size, size];
            for (int m = 0; m < btn.GetLength(0); m++)         // Loop for x
            {
                for (int n = 0; n < btn.GetLength(1); n++)     // Loop for y
                {
                    btn[m, n] = new Button();
                    btn[m, n].FlatStyle = FlatStyle.Flat;
                    btn[m, n].FlatAppearance.BorderSize = 1;
                    btn[m, n].FlatAppearance.BorderColor = Color.Black;
                    btn[m, n].SetBounds(35 * m, 25 + (35 * n), 35, 35);
                    btn[m, n].BackColor = Color.White;
                    btn[m, n].Font = new Font("Comic Sans MS", 12.0F, btn[m, n].Font.Style, btn[m, n].Font.Unit);
                    btn[m, n].ForeColor = Color.White;
                    btn[m, n].MouseDown += new MouseEventHandler(this.btnEvent_MouseDown);
                    //btn[x, y].RightClick += new EventHandler(this.btnEvent_RightClick);
                    Controls.Add(btn[m, n]);
                }

            }

            Label title = new Label();
            title.Name = "Title";
            title.Text = "Bomb Finder";
            title.Font = new Font("Comic Sans MS", 22.0F);
            title.SetBounds((35 * size) + 20, 60, 205, 40);
            Controls.Add(title);

            timer = new Label();
            timer.Name = "Timer";
            timer.Text = "Time elapsed: 0 sec";
            timer.Font = new Font("Comic Sans MS", 14.0F);
            timer.SetBounds((35 * size) + 20, 130, 215, 30);
            Controls.Add(timer);

            for (int i = 0; i < bombs; i++)
            {
                btn[r.Next(btn.GetLength(0)), r.Next(btn.GetLength(1))].Name = "Bomb";
            }
            numbers();
            timer1.Start();
        }

        void numbers()
        {
            int num = 0;
            String value = "";
            for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
            {
                for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
                {
                    num = 0;
                    value = "";
                    if (btn[x, y].Name != "Bomb")
                    {
                        if (y == 0 || y == btn.GetLength(1) - 1 || x == btn.GetLength(0) - 1 || x == 0)
                        {
                            if (y == 0 && x == 0)
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
                            else if (y == 0 && x == btn.GetLength(0) - 1)
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
                            else if (x == 0 && y == btn.GetLength(1) - 1)
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
                            else if (x == btn.GetLength(0) - 1 && y == btn.GetLength(1) - 1)
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
                            else if (y == 0)
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
                            else if (x == 0)
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
                            else if (y == btn.GetLength(1) - 1)
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
                            else if (x == btn.GetLength(0) - 1)
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
                            value = Convert.ToString(num);
                            btn[x, y].Name = value;
                            //btn[x, y].Text = value;
                            num = 0;
                            value = "";
                        }
                        else
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
                            value = Convert.ToString(num);
                            btn[x, y].Name = value;
                            //btn[x, y].Text = value;
                            num = 0;
                            value = "";
                        }
                    }
                }
            }
        }

        int uncoverZero(int x, int y, int layer)
        {
            if ((x < 0 || x >= btn.GetLength(0) || y < 0 || y >= btn.GetLength(1)) || btn[x, y].BackColor == Color.ForestGreen)
            {
                return 0;
            }
            else
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
        
        
        void btnEvent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                if (((Button)sender).BackgroundImage == null && ((Button)sender).BackColor == Color.White) { 
                    //((Button)sender).BackColor = Color.Orange;
                    ((Button)sender).BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "flag.png");
                    if (((Button)sender).Name == "Bomb")
                    {
                        correctFlags++;
                    }
                    else
                    {
                        wrongFlags++;
                    }

                }
                else //if(((Button)sender).BackgroundImage != null)
                {
                    //((Button)sender).BackColor = Color.White;
                    ((Button)sender).BackgroundImage = null;
                    if (((Button)sender).Name == "Bomb")
                    {
                        correctFlags--;
                    }
                    else
                    {
                        wrongFlags--;
                    }
                }
            }
            else 
            {
                if (((Button)sender).Name == "Bomb")
                {
                    ((Button)sender).BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "bomb.png");
                    ((Button)sender).BackColor = Color.Red;    // Change colour
                    for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
                    {
                        for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
                        {
                            if(btn[x,y].Name == "Bomb")
                            {
                                btn[x, y].BackColor = Color.Red;
                                btn[x, y].BackgroundImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "bomb.png");
                            }
                        }
                    }
                    SoundPlayer sl = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "\\Explosion.wav");
                    sl.Play();
                    timer1.Stop();
                    MessageBox.Show("Game Over!" + Environment.NewLine + "You survived for " + Convert.ToString(gameTime) + " seconds", "Game Over!");

                    Controls.Clear();
                    runGame();

                }
                else if (((Button)sender).Name == "0")
                {
                    int x = ((Button)sender).Left / 35;
                    int y = (((Button)sender).Top - 25) / 35;
                    uncoverZero(x, y, 0);
                    //Console.WriteLine("Missed!");
                }
                else
                {
                    ((Button)sender).BackColor = Color.Green;
                    ((Button)sender).Text = ((Button)sender).Name;

                }
            }

            if (correctFlags == bombs && wrongFlags == 0)
            {
                sw.Play();
                timer1.Stop();
                MessageBox.Show("You won!" + Environment.NewLine + "You found all the bombs in " + Convert.ToString(gameTime) + " seconds!", "Winner!");
                
            }
        }
        private void MineSweeper_Load(object sender, EventArgs e)  //REQUIRED
        { 
        }

        private void NewGameDropDown_Click(object sender, EventArgs e)
        {
            
        }

        private void RulesDropDown_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Bomb Finder. You must left click on boxes to reveal what is underneath them. You are trying to reveal all the squares without pressing a bomb. The numbers show how many bombs are around the square. Right click to flag the bombs. Good Luck :)");

        }

        private void ExitDropDown_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void easyGameMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls.Clear();
            size = 10;
            bombs = 10;
            se.Play();
            runGame();
        }

        private void mediumGameMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls.Clear();
            size = 15;
            bombs = 40;
            sm.Play();
            runGame();
        }

        private void hardGameMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls.Clear();
            size = 25;
            bombs = 80;
            sh.Play();
            runGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameTime++;
            timer.Text = "Time elapsed: " + Convert.ToString(gameTime) + " sec";
        }

        private void OptionsDropDown_Click(object sender, EventArgs e)
        {

        }
    }
}
