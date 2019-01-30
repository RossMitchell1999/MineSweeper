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

namespace MineSweeper
{
    public partial class MineSweeper : Form
    {
        Button[,] btn = new Button[10, 10];
        Random r = new Random();
        public MineSweeper()
        {
            InitializeComponent();
            for (int m = 0; m < btn.GetLength(0); m++)         // Loop for x
            {
                for (int n = 0; n < btn.GetLength(1); n++)     // Loop for y
                {
                    btn[m, n] = new Button();
                    btn[m, n].SetBounds(25 * m, 25 * n, 25, 25);
                    btn[m, n].BackColor = Color.White;
                    btn[m, n].MouseDown += new MouseEventHandler(this.btnEvent_MouseDown);
                    //btn[x, y].RightClick += new EventHandler(this.btnEvent_RightClick);
                    Controls.Add(btn[m, n]);
                }

            }
            for (int i = 0; i < 15; i++)
            {
                btn[r.Next(btn.GetLength(0)), r.Next(btn.GetLength(1))].Name = "Bomb";
            }
            numbers();
        }

        void numbers()
        {
            int num = 0;
            String value = "";
            for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
            {
                for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
                {
                    if (btn[x, y].Name != "Bomb")
                    {
                        if (y == 0 || y == btn.GetLength(1) - 1 || x == btn.GetLength(0) - 1 || x == 0)
                        {
                            if (y == 0 && x == 0)
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x + 1, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }

                            }
                            else if (y == 0 && x == btn.GetLength(0) - 1)
                            {
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }

                            }
                            else if (x == 0 && y == btn.GetLength(1) - 1)
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x + 1, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }

                            }
                            else if (x == btn.GetLength(0) - 1 && y == btn.GetLength(1) - 1)
                            {
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                            }
                            else if (y == 0)
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x + 1, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                            }
                            else if (x == 0)
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x + 1, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x + 1, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                            }
                            else if (y == btn.GetLength(1) - 1)
                            {
                                if (btn[x + 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x + 1, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                            }
                            else if (x == btn.GetLength(0) - 1)
                            {
                                if (btn[x, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y + 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                                if (btn[x - 1, y - 1].Name == "Bomb")
                                {
                                    num = num + 1;
                                }
                            }
                            value = Convert.ToString(num);
                            btn[x, y].Name = value;
                            num = 0;
                            value = "";
                        }
                        else
                        {
                            if (btn[x + 1, y].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x - 1, y].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x, y + 1].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x, y - 1].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x - 1, y + 1].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x + 1, y - 1].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x - 1, y - 1].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            if (btn[x + 1, y + 1].Name == "Bomb")
                            {
                                num = num + 1;
                            }
                            value = Convert.ToString(num);
                            btn[x, y].Name = value;
                            num = 0;
                            value = "";
                        }
                    }
                }
            }
        } 
        void btnEvent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                if (((Button)sender).BackColor == Color.White) { 
                    ((Button)sender).BackColor = Color.Orange;

                }
                else if(((Button)sender).BackColor == Color.White)
                {
                    ((Button)sender).BackColor = Color.White;
                }
            }
            else 
            {
                if (((Button)sender).Name == "Bomb")
                {
                    ((Button)sender).BackColor = Color.Red;    // Change colour
                    for (int x = 0; x < btn.GetLength(0); x++)         // Loop for x
                    {
                        for (int y = 0; y < btn.GetLength(1); y++)     // Loop for y
                        {
                            if(btn[x,y].Name == "Bomb")
                            {
                                (btn[x,y]).BackColor = Color.Red;
                            }
                        }
                    }
                    MessageBox.Show("Game Over!");
                    //Controls.Clear();
                    //InitializeComponent();

                }
                else
                {
                    ((Button)sender).BackColor = Color.Green;
                    ((Button)sender).Text = ((Button)sender).Name;

                }
            }
        }
        private void MineSweeper_Load(object sender, EventArgs e)  //REQUIRED
        {
        }

        private void NewGameDropDown_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);
            InitializeComponent();
        }

        private void RulesDropDown_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is MineSweeper. You must left click on boxes to reveal what is underneath them. You are trying to reveal all the squares without pressing a bomb. The numbers show how many bombs are around the square. Right click to flag the bombs. Good Luck :)");

        }

        private void ExitDropDown_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
