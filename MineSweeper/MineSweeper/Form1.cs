using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                    btn[m, n].Click += new EventHandler(this.btnEvent_Click);
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
                        }
                        value = Convert.ToString(num);
                        btn[x, y].Name = value;
                        num = 0;
                        value = "";
                    }
                }
            }
        } 
        void btnEvent_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "Bomb")  // Is clicked one blue?
            {                                                     // YES
                ((Button)sender).BackColor = Color.Red;    // Change colour
                btn[r.Next(btn.GetLength(0)), r.Next(btn.GetLength(1))].Name = "Bomb"; // Pick new mole
                                   // Output message
            }
            else{                                                  // NO
                //Console.WriteLine("Missed!");                         // Output message
                ((Button)sender).BackColor = Color.Green;
                ((Button)sender).Text = ((Button)sender).Name;

                //Console.WriteLine(((Button)sender).Text);    // SAME handler as before
            }
        }
        private void MineSweeper_Load(object sender, EventArgs e)  //REQUIRED
        {
        }


    }
}
