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
    public partial class Interface : Form
    {
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
            System.Drawing.Point point = new Point();
            point.X = 1;
            point.Y = 1;

            int[,] celltable = new int[40,40];

            dataGridView1.CurrentCell = this.dataGridView1.FirstDisplayedCell;
            dataGridView1.CurrentCell.Value = 7;
            //for (int i = 0; i < 40; i++)
            //{
            //    for (int j = 0; j < 40; j++)
            //    {
            //        if (map.Tilemap[i, j].Wall)
            //        {
            //            dataGridView1.CurrentCell
            //        }

            //    }
            //}


            Console.WriteLine(this.dataGridView1.CurrentCell);
            

        }
    }
}
