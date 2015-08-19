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
        //private Floor map;
        
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
            Floor map = new Floor(40, 40, 500, 500, 0);
            
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


            //Console.WriteLine(this.dataGridView1.CurrentCell);
            //Console.WriteLine("testing");
            

        }
    }
}
