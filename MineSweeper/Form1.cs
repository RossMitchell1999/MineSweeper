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
        public Button[,] btn = new Button[10, 10];
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

        void uncoverZero(int x, int y, int layer)
        {
            
            bool numFoundX = false;
            bool numFoundY = false;
            int ip = x;
            int jp = y;
            int im = x;
            int jm = y - 1;
            int layerX = 0;
            int layerY = 0;
            while (numFoundX != true && ip < btn.GetLength(0))
            {

                while (numFoundY != true && jp < btn.GetLength(1))
                {
                    if (btn[ip, jp].BackColor == Color.White)
                    {
                        btn[ip, jp].BackColor = Color.Green;
                        btn[ip, jp].Text = btn[ip, jp].Name;

                        jp++;
                        if (jp < btn.GetLength(1) && btn[ip, jp].Name != "0")
                        {
                            layerY++;
                            if (layerY == 2)
                            {
                                numFoundY = true;
                            }
                        }
                    }
                    else
                    {
                        numFoundY = true;
                    }
                }
                numFoundY = false;
                layerY = 0;
                while (numFoundY != true && jm >= 0)
                {
                    if (btn[ip, jm].BackColor == Color.White)
                    {
                        btn[ip, jm].BackColor = Color.Green;
                        btn[ip, jm].Text = btn[ip, jm].Name;

                        jm--;
                        if (jm >= 0 && btn[ip, jm].Name != "0")
                        {
                            layerY++;
                            if (layerY == 2)
                            {
                                numFoundY = true;
                            }
                        }
                    }
                    else
                    {
                        numFoundY = true;
                    }
                }


                jp = y;
                jm = y - 1;
                numFoundY = false;
                ip++;
                if (ip < btn.GetLength(0) && btn[ip, jp].Name != "0")
                {
                    layerX++;
                    if (layerX == 2)
                    {
                        numFoundX = true;
                    }
                }
            }

            layerX = 0;
            layerY = 0;
            numFoundX = false;
            numFoundY = false;

            while (numFoundX != true && im > 0)
            {

                while (numFoundY != true && jp < btn.GetLength(1))
                {
                    if (btn[im, jp].BackColor == Color.White)
                    {
                        btn[im, jp].BackColor = Color.Green;
                        btn[im, jp].Text = btn[im, jp].Name;

                        jp++;
                        if (jp < btn.GetLength(1) && btn[im, jp].Name != "0")
                        {
                            layerY++;
                            if (layerY == 2)
                            {
                                numFoundY = true;
                            }
                        }
                    }
                    else
                    {
                        numFoundY = true;
                    }
                }
                numFoundY = false;
                layerY = 0;
                while (numFoundY != true && jm >= 0)
                {
                    if (btn[im, jm].BackColor == Color.White)
                    {
                        btn[im, jm].BackColor = Color.Green;
                        btn[im, jm].Text = btn[im, jm].Name;

                        jm--;
                        if (jm >= 0 && btn[im, jm].Name != "0")
                        {
                            layerY++;
                            if (layerY == 2)
                            {
                                numFoundY = true;
                            }
                        }
                    }
                    else
                    {
                        numFoundY = true;
                    }
                }


                jp = y;
                jm = y - 1;
                numFoundY = false;
                im--;
                if (im < btn.GetLength(0) && btn[im, jp].Name != "0")
                {
                    layerX++;
                    if (layerX == 2)
                    {
                        numFoundX = true;
                    }
                }
            }
        }
            

        
        




        void btnEvent_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "Bomb")  // Is clicked one blue?
            {                                                     // YES
                ((Button)sender).BackColor = Color.Red;    // Change colour
                                                           //btn[r.Next(btn.GetLength(0)), r.Next(btn.GetLength(1))].Name = "Bomb"; // Pick new mole
                                                           // Output message
            }
            else
            {
                //Console.WriteLine("Missed!");                         // Output message

                if (((Button)sender).Name == "0")
                {
                    int x = (((Button)sender).Left) / 25;
                    int y = (((Button)sender).Top) / 25;
                    Console.WriteLine("X: " + x + ", Y: " + y);
                    //int[] index = Array.IndexOf(Button, (Button)sender);
                    uncoverZero(x, y, 0);
                }
                else
                {
                    ((Button)sender).BackColor = Color.Green;
                    ((Button)sender).Text = ((Button)sender).Name;
                }

                //Console.WriteLine(((Button)sender).Text);    // SAME handler as before
            }
        }



        private void MineSweeper_Load(object sender, EventArgs e)  //REQUIRED
        {
        }


    }
}
