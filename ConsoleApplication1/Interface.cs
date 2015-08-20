using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    //public class InterfaceOperations
    //{
    //    public Floor floorplan;

    //    public void GetMap(Floor floor)
    //    {
    //        floorplan = floor;
    //    }
    //}
    
    public partial class Interface : Form
    {
        private Floor map = new Floor(40, 40, 500, 500, 0);
        public void PlayerMove(int x, int y)
        {
            
        }

        public void viewEval(int x, int y)
        {
            int xtemp;
            int ytemp;
            for (double theta = 0; theta < 360; theta+= .2)
            {
                for (double a = 1; a < 60; a+= .5)
                {
                    xtemp = Convert.ToInt32(x + a * Math.Cos(theta));
                    ytemp = Convert.ToInt32(y + a * Math.Sin(theta));
                    map.visiblemap[xtemp, ytemp] = 1;
                    if (this.map.Tilemap[xtemp,ytemp].Wall)
                    {                        
                        break;
                    }
                }
            }
        }

        public Interface()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 40;
            dataGridView1.RowCount = 40;
            for (int i = 0; i < 40; i++)
            {
                dataGridView1.Columns[i].Width = 10;
                dataGridView1.Rows[i].Height = 10;
            }
            

            int[,] celltable = new int[40,40];

            //dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            //dataGridView1.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.Black;
            //dataGridView1.CurrentCell.Value = 7;
            //Floor map2 = new Floor(40, 40, 500, 500, 0);
            //for (int i = 0; i < 40; i++)
            //{
            //    for (int j = 0; j < 40; j++)
            //    {
            //        this.map.Tilemap = map2.Tilemap;

            //    }
            //}
            //this.map = map2;
            //this.map.Tilemap = map2.Tilemap;
            
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (map.Tilemap[i, j].Wall)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                    }

                }
            }

            //Part of testing out the visibility stuff
            Party tempParty = new Party();
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (!map.Tilemap[i, j].Wall)
                    {
                        tempParty.X = i;
                        tempParty.Y = j;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Red;
                        goto Bpt;
                    }
                }
            }
            Bpt:
                System.Console.WriteLine("placeholder");
            viewEval(tempParty.X, tempParty.Y);

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (map.visiblemap[i,j] == 1)
                    {
                        if (map.Tilemap[i, j].Wall)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Blue;
                        }
                        else
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Yellow;

                    }
                }
            }

            //Console.WriteLine(this.dataGridView1.CurrentCell);
            //Console.WriteLine("testing");
            

        }
    }
}
