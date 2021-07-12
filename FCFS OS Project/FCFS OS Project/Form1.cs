using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCFS_OS_Project
{
    public partial class Form1 : Form
    {
        public class Actor
        {
            public int X, Y, Width, Height;
            public Brush SB;
            public Actor()
            {

            }
            public Actor(Brush SB, int X,int Y,int Width, int Height)
            {
                this.SB = SB;
                this.X = X;
                this.Y = Y;
                this.Width = Width;
                this.Height = Height;
            }
        }

        public class Proccess
        {
            public int ID;
            public int BrustTime;
            public int FlagDone;
            public int ArrivalTime;
            public int FlagDrawn = 0;

            public Label P = new Label();
            public Actor pnn = new Actor();

            public Proccess(int id, int BrustTime,int flagDone,int arrivaltime)
            {
                this.ID = id;
                this.BrustTime = BrustTime;
                this.FlagDone = flagDone;
                this.ArrivalTime = arrivaltime;
            }
        }

        void CalculateWithAriivalTime()
        {
            Proccess pnn = new Proccess(1, Convert.ToInt32(textBox1.Text.Trim()), 0, Convert.ToInt32(textBox15.Text.Trim()));
            ProccessD.Add(pnn);
            pnn = new Proccess(2, Convert.ToInt32(textBox2.Text.Trim()),0, Convert.ToInt32(textBox16.Text.Trim()));
            ProccessD.Add(pnn);
            pnn = new Proccess(3, Convert.ToInt32(textBox3.Text.Trim()), 0, Convert.ToInt32(textBox17.Text.Trim()));
            ProccessD.Add(pnn);
            pnn = new Proccess(4, Convert.ToInt32(textBox4.Text.Trim()), 0, Convert.ToInt32(textBox18.Text.Trim()));
            ProccessD.Add(pnn);

            int min = 9999999;
            int FC = 0;

            for(int i = 0;i<ProccessD.Count;i++)
            {
                if(ProccessD[i].ArrivalTime < min && ProccessD[i].FlagDone == 0)
                {
                    min = ProccessD[i].ArrivalTime;
                    FC = ProccessD[i].ID;
                }
            }

            for (int i = 0; i < ProccessD.Count; i++)
            {
                if(ProccessD[i].ID == FC)
                {
                    if (FC == 1)
                    {
                        textBox5.Text = "0";
                        textBox9.Text = Convert.ToString(ProccessD[i].BrustTime);
                        ProccessD[i].FlagDone = 1;

                        ProccessD[i].pnn = new Actor(Brushes.Black, 0, 200, 0, 50);
                        ProccessD[i].P.Text = "P1";
                        ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                        ProccessD[i].P.Show();
                    }
                    else if(FC == 2)
                    {
                        textBox6.Text = "0";
                        textBox10.Text = Convert.ToString(ProccessD[i].BrustTime);
                        ProccessD[i].FlagDone = 1;

                        ProccessD[i].pnn = new Actor(Brushes.Brown, 0, 200, 0, 50);
                        ProccessD[i].P.Text = "P2";
                        ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                        ProccessD[i].P.Show();
                    }
                    else if(FC == 3)
                    {
                        textBox7.Text = "0";
                        textBox11.Text = Convert.ToString(ProccessD[i].BrustTime);
                        ProccessD[i].FlagDone = 1;

                        ProccessD[i].pnn = new Actor(Brushes.Azure, 0, 200, 0, 50);
                        ProccessD[i].P.Text = "P3";
                        ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                        ProccessD[i].P.Show();
                    }
                    else if(FC == 4)
                    {
                        textBox8.Text = "0";
                        textBox12.Text = Convert.ToString(ProccessD[i].BrustTime);
                        ProccessD[i].FlagDone = 1;

                        ProccessD[i].pnn = new Actor(Brushes.Bisque, 0, 200, 0, 50);
                        ProccessD[i].P.Text = "P4";
                        ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                        ProccessD[i].P.Show();
                    }
                }
            }
            for (; ; )
            {
                if(ProccessD[0].FlagDone == 1 && ProccessD[1].FlagDone == 1 && ProccessD[2].FlagDone == 1 && ProccessD[3].FlagDone == 1)
                {
                    break;
                }
                min = 9999999;
                for (int i = 0; i < ProccessD.Count; i++)
                {
                    if (ProccessD[i].ArrivalTime < min && ProccessD[i].FlagDone == 0)
                    {
                        min = ProccessD[i].ArrivalTime;
                        FC = ProccessD[i].ID;
                    }
                }
            
                for (int i = 0; i < ProccessD.Count; i++)
                {
                    if (ProccessD[i].ID == FC)
                    {
                        if (FC == 1)
                        {
                            int waitingTime = 0;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    waitingTime += ProccessD[w].BrustTime;
                                }
                            }

                            waitingTime -= ProccessD[i].ArrivalTime;

                            textBox5.Text = Convert.ToString(waitingTime);

                            int TurnAroundTime = ProccessD[i].BrustTime;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    TurnAroundTime += ProccessD[w].BrustTime;
                                }
                            }
                            textBox9.Text = Convert.ToString(TurnAroundTime);
                            ProccessD[i].FlagDone = 1;

                            ProccessD[i].pnn = new Actor(Brushes.Black, waitingTime, 200, 0, 50);
                            ProccessD[i].P.Text = "P1";
                            ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                            ProccessD[i].P.Show();
                        }
                        else if (FC == 2)
                        {
                            int waitingTime = 0;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    waitingTime += ProccessD[w].BrustTime;
                                }
                            }

                            waitingTime -= ProccessD[i].ArrivalTime;

                            textBox6.Text = Convert.ToString(waitingTime);

                            int TurnAroundTime = ProccessD[i].BrustTime;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    TurnAroundTime += ProccessD[w].BrustTime;
                                }
                            }
                            textBox10.Text = Convert.ToString(TurnAroundTime);
                            ProccessD[i].FlagDone = 1;

                            ProccessD[i].pnn = new Actor(Brushes.Brown, waitingTime, 200, 0, 50);
                            ProccessD[i].P.Text = "P2";
                            ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                            ProccessD[i].P.Show();
                        }
                        else if (FC == 3)
                        {
                            int waitingTime = 0;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    waitingTime += ProccessD[w].BrustTime;
                                }
                            }

                            waitingTime -= ProccessD[i].ArrivalTime;

                            textBox7.Text = Convert.ToString(waitingTime);

                            int TurnAroundTime = ProccessD[i].BrustTime;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    TurnAroundTime += ProccessD[w].BrustTime;
                                }
                            }
                            textBox11.Text = Convert.ToString(TurnAroundTime);
                            ProccessD[i].FlagDone = 1;

                            ProccessD[i].pnn = new Actor(Brushes.Azure, waitingTime, 200, 0, 50);
                            ProccessD[i].P.Text = "P3";
                            ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                            ProccessD[i].P.Show();
                        }
                        else if (FC == 4)
                        {
                            int waitingTime = 0;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    waitingTime += ProccessD[w].BrustTime;
                                }
                            }

                            waitingTime -= ProccessD[i].ArrivalTime;

                            textBox8.Text = Convert.ToString(waitingTime);

                            int TurnAroundTime = ProccessD[i].BrustTime;

                            for (int w = 0; w < ProccessD.Count; w++)
                            {
                                if (ProccessD[w].FlagDone == 1)
                                {
                                    TurnAroundTime += ProccessD[w].BrustTime;
                                }
                            }
                            textBox12.Text = Convert.ToString(TurnAroundTime);
                            ProccessD[i].FlagDone = 1;

                            ProccessD[i].pnn = new Actor(Brushes.Bisque, waitingTime, 200, 0, 50);
                            ProccessD[i].P.Text = "P4";
                            ProccessD[i].P.Location = new Point(ProccessD[i].pnn.X, ProccessD[i].pnn.Y);
                            ProccessD[i].P.Show();
                        }
                    }
                }
            }

            //Average Waitig Time And TurnAround Time Calculation For Each (P)//

            int averageWaitingTime = Convert.ToInt32(textBox5.Text.Trim()) + Convert.ToInt32(textBox6.Text.Trim()) + Convert.ToInt32(textBox7.Text.Trim()) + Convert.ToInt32(textBox8.Text.Trim());
            averageWaitingTime = averageWaitingTime / 4;

            int averageTurnaroundTime = Convert.ToInt32(textBox9.Text.Trim()) + Convert.ToInt32(textBox10.Text.Trim()) + Convert.ToInt32(textBox11.Text.Trim()) + Convert.ToInt32(textBox12.Text.Trim());
            averageTurnaroundTime = averageTurnaroundTime / 4;

            //Adding The Averages to The TextBox Assigned for each value//

            textBox14.Text = Convert.ToString(averageTurnaroundTime);
            textBox13.Text = Convert.ToString(averageWaitingTime);

            DrawScene(this.CreateGraphics());
        }

        public void Calculate()
        {
            //P1
            int startingTime = 0;
            int endingTime = Convert.ToInt32(textBox1.Text.Trim());

            //Adding Waiting Time and TurnAround Time for each TextBox//

            textBox5.Text = Convert.ToString(startingTime);
            textBox9.Text = Convert.ToString(endingTime);

            Actor pnn = new Actor(Brushes.Black,0, 200, Convert.ToInt32(textBox1.Text.Trim()), 28);
            GantChart.Add(pnn);

            //P2

            startingTime = Convert.ToInt32(textBox1.Text.Trim());
            endingTime = Convert.ToInt32(textBox2.Text.Trim()) + Convert.ToInt32(textBox1.Text.Trim());

            //Adding Waiting Time and TurnAround Time for each TextBox//

            textBox6.Text = Convert.ToString(startingTime);
            textBox10.Text = Convert.ToString(endingTime);

            pnn = new Actor(Brushes.Red , Convert.ToInt32(textBox1.Text.Trim()) + 100, 200, Convert.ToInt32(textBox2.Text.Trim()), 28);
            GantChart.Add(pnn);
            //P3

            startingTime = Convert.ToInt32(textBox1.Text.Trim()) + Convert.ToInt32(textBox2.Text.Trim());
            endingTime = Convert.ToInt32(textBox2.Text.Trim()) + Convert.ToInt32(textBox1.Text.Trim()) + Convert.ToInt32(textBox3.Text.Trim());

            //Adding Waiting Time and TurnAround Time for each TextBox//

            textBox7.Text = Convert.ToString(startingTime);
            textBox11.Text = Convert.ToString(endingTime);

            pnn = new Actor(Brushes.Yellow , Convert.ToInt32(textBox1.Text.Trim()) + Convert.ToInt32(textBox2.Text.Trim()), 200, Convert.ToInt32(textBox3.Text.Trim()) + 100, 28);
            GantChart.Add(pnn);

            //P4

            startingTime = Convert.ToInt32(textBox1.Text.Trim()) + Convert.ToInt32(textBox2.Text.Trim()) + Convert.ToInt32(textBox3.Text.Trim());
            endingTime = Convert.ToInt32(textBox2.Text.Trim()) + Convert.ToInt32(textBox1.Text.Trim()) + Convert.ToInt32(textBox3.Text.Trim()) + Convert.ToInt32(textBox4.Text.Trim());
            
            //Adding Waiting Time and TurnAround Time for each TextBox//

            textBox8.Text = Convert.ToString(startingTime);
            textBox12.Text = Convert.ToString(endingTime);

            pnn = new Actor(Brushes.Aqua , Convert.ToInt32(textBox1.Text.Trim()) + Convert.ToInt32(textBox2.Text.Trim()) + Convert.ToInt32(textBox3.Text.Trim()), 200, Convert.ToInt32(textBox4.Text.Trim()) + 100, 28);
            GantChart.Add(pnn);

            //Average Waitig Time And TurnAround Time Calculation For Each (P)//

            int averageWaitingTime = Convert.ToInt32(textBox5.Text.Trim()) + Convert.ToInt32(textBox6.Text.Trim()) + Convert.ToInt32(textBox7.Text.Trim()) + Convert.ToInt32(textBox8.Text.Trim());
            averageWaitingTime = averageWaitingTime / 4;

            int averageTurnaroundTime = Convert.ToInt32(textBox9.Text.Trim()) + Convert.ToInt32(textBox10.Text.Trim()) + Convert.ToInt32(textBox11.Text.Trim()) + Convert.ToInt32(textBox12.Text.Trim());
            averageTurnaroundTime = averageTurnaroundTime / 4;

            //Adding The Averages to The TextBox Assigned for each value//

            textBox14.Text = Convert.ToString(averageTurnaroundTime);   
            textBox13.Text = Convert.ToString(averageWaitingTime);


            DrawScene(this.CreateGraphics());
        }

        int FlagBox1;
        int FlagBox2;

        List<Actor> GantChart = new List<Actor>();
        List<Proccess> ProccessD = new List<Proccess>();

        public void DrawScene(Graphics g)
        {
            g.Clear(Color.Gold);

            if (GantChart.Count == 0)
            {
                label11.Text = "P1";
                label11.Hide();
                label12.Text = "P2";
                label12.Hide();
                label13.Text = "P3";
                label13.Hide();
                label14.Text = "P4";
                label14.Hide();

                g.Clear(Color.Gold);

                for (int i = 0; i < ProccessD.Count;)
                {
                    int min = 99999;
                    int ToBeDrawn = 0;

                    for (int w = 0; w < ProccessD.Count; w++)
                    {
                        if (ProccessD[w].pnn.X < min && ProccessD[w].FlagDrawn == 0)
                        {
                            min = ProccessD[w].pnn.X;
                            ToBeDrawn = w;
                        }
                    }
                
                    g.FillRectangle(ProccessD[ToBeDrawn].pnn.SB, ProccessD[ToBeDrawn].pnn.X, ProccessD[ToBeDrawn].pnn.Y, ProccessD[ToBeDrawn].pnn.Width, ProccessD[ToBeDrawn].pnn.Height);

                    if (ProccessD[ToBeDrawn].ID == 1)
                    {
                        label11.Location = new Point(ProccessD[ToBeDrawn].pnn.X, ProccessD[ToBeDrawn].pnn.Y);
                        label11.Show();
                        label16.Location = new Point(ProccessD[ToBeDrawn].pnn.X + ProccessD[ToBeDrawn].pnn.Width, ProccessD[ToBeDrawn].pnn.Y + ProccessD[ToBeDrawn].pnn.Height);
                        label16.Text = textBox9.Text.Trim();
                        label16.Show();
                    }
                    else if (ProccessD[ToBeDrawn].ID == 2)
                    {
                        label12.Location = new Point(ProccessD[ToBeDrawn].pnn.X, ProccessD[ToBeDrawn].pnn.Y);
                        label12.Show();
                        label17.Location = new Point(ProccessD[ToBeDrawn].pnn.X + ProccessD[ToBeDrawn].pnn.Width, ProccessD[ToBeDrawn].pnn.Y + ProccessD[ToBeDrawn].pnn.Height);
                        label17.Text = textBox10.Text.Trim();
                        label17.Show();
                    }
                    else if (ProccessD[ToBeDrawn].ID == 3)
                    {
                        label13.Location = new Point(ProccessD[ToBeDrawn].pnn.X, ProccessD[ToBeDrawn].pnn.Y);
                        label13.Show();
                        label18.Location = new Point(ProccessD[ToBeDrawn].pnn.X + ProccessD[ToBeDrawn].pnn.Width, ProccessD[ToBeDrawn].pnn.Y + ProccessD[ToBeDrawn].pnn.Height);
                        label18.Text = textBox11.Text.Trim();
                        label18.Show();
                    }
                    else if (ProccessD[ToBeDrawn].ID == 4)
                    {
                        label14.Location = new Point(ProccessD[ToBeDrawn].pnn.X, ProccessD[ToBeDrawn].pnn.Y);
                        label14.Show();
                        label19.Location = new Point(ProccessD[ToBeDrawn].pnn.X + ProccessD[ToBeDrawn].pnn.Width, ProccessD[ToBeDrawn].pnn.Y + ProccessD[ToBeDrawn].pnn.Height);
                        label19.Text = textBox12.Text.Trim();
                        label19.Show();
                    }

                        if (ProccessD[ToBeDrawn].pnn.Width >= ProccessD[ToBeDrawn].BrustTime)
                        {
                            i++;
                            ProccessD[ToBeDrawn].FlagDrawn = 1;
                        }
                        else
                        {
                            ProccessD[ToBeDrawn].pnn.Width += 20;
                        }

                    System.Threading.Thread.Sleep(1000);
                }
            }
            else
            {
                label11.Text = "P1";
                label11.Location = new Point(GantChart[0].X, GantChart[0].Y);
                label11.Show();

                label12.Text = "P2";
                label12.Location = new Point(GantChart[1].X, GantChart[1].Y);
                label12.Show();

                label13.Text = "P3";
                label13.Location = new Point(GantChart[2].X, GantChart[2].Y);
                label13.Show();

                label14.Text = "P4";
                label14.Location = new Point(GantChart[3].X, GantChart[3].Y);
                label14.Show();

                for (int i = 0; i < GantChart.Count; i++)
                {
                    g.FillRectangle(GantChart[i].SB, GantChart[i].X, GantChart[i].Y, GantChart[i].Width, GantChart[i].Height);
                }
            }
            
        }

        Timer tt = new Timer();
        int counter = 0;
        public Form1()   
        {
            InitializeComponent();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FlagBox1 = 1;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            FlagBox2 = 1;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox15.Text.Length == 0)
           {
                textBox15.Text = "0";
           }

           if(textBox16.Text.Length == 0)
           {
                textBox16.Text = "0";
           }

           if (textBox17.Text.Length == 0)
           {
                textBox17.Text = "0";
           }

           if (textBox18.Text.Length == 0)
           {
                textBox18.Text = "0";
           }

            CalculateWithAriivalTime();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clearing All The Text Boxes//
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();

            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();

            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            //Clearing All The Text Boxes(Completed)//

            //Clearing The Proccess List//
            ProccessD.Clear();
            //Clearing The Proccess List(Completed)//

            //Clear Screen//
            ClearScreen(this.CreateGraphics());
            //Clear Screen (Completed)//

            //Reset Labels//
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            //Reset Labels(Completed)//
        }
        void ClearScreen(Graphics g)
        {
            g.Clear(Color.Beige);
        }
    }
    
}
