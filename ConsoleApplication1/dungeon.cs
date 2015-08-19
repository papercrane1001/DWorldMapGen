using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
    
    class Item
    {

    }

    class Construction
    {
        private int[] direction; //[1, 0], [-1, 0], [0, 1], [0, -1]
        private int[] position;
        private int edgecounter = 0;
        private Random rand = new Random();
        public int[] Position
        {
            get { return position; }
            set { position = value; }
        }
        public int[] Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public int Counter
        {
            get { return edgecounter; }
            set { edgecounter = value; }
        }
        public string Choose()
        {
            string choice;
            int dir = rand.Next(1,9);
            if (dir < 7)
                choice = "str";
                //this.Move(this.position,this.direction);
            else //if (dir < 9)
                choice = "turn";
                //this.Turn();
            //else 
            //    choice = "room";
            return choice;
        }
        public void Turn()
        {
            if (this.direction[0] != 0)
            {
                this.direction[0] = 0;
                this.direction[1] = rand.Next(0, 2) * 2 - 1;
            }
            else if (this.direction[1] != 0)
            {
                this.direction[1] = 0;
                this.direction[0] = rand.Next(0, 2) * 2 - 1;
            }

        }
        public void Move()
        {
            
            this.position[0] = this.position[0] + this.direction[0];
            this.position[1] = this.position[1] + this.direction[1];
        }
        public void MoveBack()
        {
            this.position[0] = this.position[0] - this.direction[0];
            this.position[1] = this.position[1] - this.direction[1];
        }
        public int[] BordersFill()
        {
            int[] pair = new int[4];
            if (this.direction[0] != 0)
            {
                pair[0] = 0;
                pair[2] = 0;
                pair[1] = 1;
                pair[3] = -1;
            }
            //pair[0]
            else if (this.direction[1] != 0)
            {
                pair[1] = 0;
                pair[3] = 0;
                pair[0] = 1;
                pair[2] = -1;
            }
            return pair;
        }
    }

    class Tile
    {
        private bool wall; // 1 = wall, 0 = floor
        private string material; // list of possible materials corresponds to colors wherever the Excel interface is
        private string explored; // if 1, reveals tiles around it.  Somewhere in dealing with Floor.
        //public string creatures;
        
        public List<Item> items;

        public Tile() 
        {
            this.wall = false;
        }

        public Tile(bool wall, string material)
        {
            this.wall = wall;
            this.material = material;

        }

        public bool Wall
        {
            get
            {
                return wall;
            }
            set
            {
                wall = value;
            }
        }
        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
            }
        }
        public List<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public string Explored
        {
            get
            {
                return explored;
            }
            set
            {
                explored = value;
            }
        }
    }
    class Floor
    {
        private Tile[,] map;
        private int[,] visiblemap;
        private Construction con = new Construction();
        private Random rand = new Random();
        public Floor() { }
        public Tile[,] Tilemap
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }
        public Floor(int xmap, int ymap, int loopmax, int quit, int CR)
        {
            map = new Tile[xmap, ymap];
            for (int i = 0; i < xmap; i++)
                for (int j = 0; j < ymap; j++)
                    map[i, j] = new Tile();
            for (int i = 0; i < xmap; i++)
            {
                this.Tilemap[i, 0].Wall = true; 
                this.Tilemap[i, ymap - 1].Wall = true; 
            }
            for (int j = 0; j < ymap; j++)
            {
                this.Tilemap[0, j].Wall = true;
                this.Tilemap[xmap - 1, j].Wall = true;
            }
            int[] startpos = {rand.Next(1,xmap-2),rand.Next(1,ymap-2)};
            int[] startdir = {1,0};
            this.con.Position = startpos;
            this.con.Direction = startdir;
            this.Tilemap[startpos[0],startpos[1]].Wall = false;

            FalseStart:
            if (this.Tilemap[startpos[0] + this.con.Direction[0], startpos[1] + this.con.Direction[1]].Wall == true)
            {
                this.con.Turn();
                goto FalseStart;
            }

            this.con.Move();
            this.map[this.con.Position[0], this.con.Position[1]].Wall = false;

            bool testcond = false;
            while (testcond == false)
            {
                int n = 0;
                n++;
                string ch = this.con.Choose();
                if (ch == "str")
                {
                    TryAgain:
                    this.con.Move();
                    if (this.con.Position[0] == 0 || this.con.Position[0] == xmap - 1 || this.con.Position[1] == 0 || this.con.Position[1] == ymap - 1)
                    {
                        this.con.Counter += 1;
                        this.con.MoveBack();
                        this.con.Turn();
                        goto TryAgain;
                    }
                    if (this.con.Counter == loopmax)
                        break;
                    this.map[this.con.Position[0], this.con.Position[1]].Wall = false;
                    this.map[this.con.Position[0] + this.con.BordersFill()[0], this.con.Position[1] + this.con.BordersFill()[1]].Wall = true;
                    this.map[this.con.Position[0] + this.con.BordersFill()[2], this.con.Position[1] + this.con.BordersFill()[3]].Wall = true;

                }
                if (ch == "turn")
                {
                    TryAgain2:
                    this.con.Turn();
                    this.con.Move();
                    if (this.con.Position[0] == 0 || this.con.Position[0] == xmap - 1 || this.con.Position[1] == 0 || this.con.Position[1] == ymap - 1)
                    {
                        this.con.Counter += 1;
                        this.con.MoveBack();
                        goto TryAgain2;
                    }

                    if (this.con.Counter == loopmax)
                        break;
                    this.map[this.con.Position[0], this.con.Position[1]].Wall = false;

                }
                if (n == quit)
                    break;
                Console.Write("Progress...");
            }

            int[] startCell = new int[2];
            bool[,] tempmap = new bool[xmap,ymap];
            int counter = 0;
            bool cbool = true;

            string[] tempLines2 = new string[40];
            for (int i = 0; i < ymap; i++)
            {
                for (int j = 0; j < xmap; j++)
                {
                    if (this.Tilemap[j, i].Wall)
                    {
                        Console.Write(1);
                        //trial1sheet1.Cells[j+1, i+1] = 1;
                        tempLines2[i] = tempLines2[i] + 1;

                    }

                    else
                    {
                        Console.Write(0);
                        //trial1sheet1.Cells[j+1, i+1] = 0;
                        tempLines2[i] = tempLines2[i] + 0;

                    }
                }
                Console.WriteLine("");
            }
            //System.IO.File.WriteAllLines(@"C:\Users\Nostariel\Desktop\New folder\WriteLines1.txt", tempLines2);

            for (int i = 1; i < xmap - 2; i++)
            {
                for (int j = 1; j < ymap - 2; j++)
                {
                    if (!this.map[i, j].Wall)
                    {
                        startCell[0] = i;
                        startCell[1] = j;
                        for (int k = 1; k < xmap - 2; k++)
                        {
                            for (int l = 1; l < ymap - 2; l++)
                            {
                                tempmap[k, l] = false;
                            }
                        }
                        tempmap[i, j] = true;
                        counter = 1;
                        cbool = true;
                        while (cbool == true)
                        {
                            cbool = false;
                            for (int k = 1; k < xmap - 2; k++)
                            {
                                for (int l = 1; l < ymap - 2; l++)
                                {
                                    if (!this.map[k, l].Wall && !tempmap[k, l])
                                    {
                                        if (tempmap[k + 1, l] || tempmap[k - 1, l] || tempmap[k, l + 1] || tempmap[k, l - 1])
                                        {
                                            tempmap[k, l] = true;
                                            counter++;
                                            cbool = true;
                                        }
                                        if (tempmap[k + 1, l + 1] || tempmap[k - 1, l + 1] || tempmap[k + 1, l - 1] || tempmap[k - 1, l - 1])
                                        {
                                            tempmap[k, l] = true;
                                            counter++;
                                            cbool = true;
                                        }

                                    }
                                }
                            }
                        }

                        if (counter * 50 < xmap * ymap)
                        {
                            for (int k = 1; k < xmap - 2; k++)
                            {
                                for (int l = 1; l < ymap - 2; l++)
                                {
                                    if (tempmap[k, l])
                                    {
                                        this.map[k, l].Wall = true;
                                    }
                                }
                            }
                            //for (int k = 0; k < ymap; k++)
                            //{
                            //    for (int l = 0; l < xmap; l++)
                            //    {
                            //        if (this.Tilemap[k, l].Wall)
                            //        {
                            //            Console.Write(1);
                            //            //trial1sheet1.Cells[j+1, i+1] = 1;
                            //        }

                            //        else
                            //        {
                            //            Console.Write(0);
                            //            //trial1sheet1.Cells[j+1, i+1] = 0;
                            //        }
                            //    }
                            //    Console.WriteLine("");
                            //}
                        }
                        
                    }
                }
            }

            //bool terminated;
            //for (int i = 0; i < xmap; i++)
            //    for (int j = 0; j < ymap; j++)
            //    {
            //        terminated = false;
            //        int[] temppos = { i, j };
            //        int[,] tempList = new int[100, 3];
            //        while (terminated != true) 
            //        {

            //            if (!map[temppos[0],temppos[1]].Wall && )

            //        }
            //        if (map[])

                //}
            //if (this.con.Choose() == "str")
            //{
            //    if (this.Tilemap[startpos[0] + startdir[0], startpos[1] + startdir[1]].Wall == true)
            //    {

            //    }
            //}
        }
    }
    class Dungeon
    {
        private Floor[] sumMap;

        public Floor[] Floor
        {
            get
            {
                return sumMap;
            }
            set
            {
                sumMap = value;
            }
        }

        public Dungeon() { }
    }
}
