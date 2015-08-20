using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Party
    {
        private int x;
        private int y;
        
        private double AttScore;
        private double DefScore;
        private List<Players> roster;

        public Party() { }

        public Party(int xpos, int ypos)
        {
            x = xpos;
            y = ypos;
        }
        public int X
        {
            get {return x;}
            set {x = value;}
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Att
        {
            get { return AttScore; }
            set { AttScore = value; }
        }
        public double Def
        {
            get { return DefScore; }
            set { DefScore = value; }
        }
    }
    
    class Players
    {
        private List<Item> itemlist;

        private int hd;
        private int dX;
        private int mod;

        private int floor;
        private int[] location = new int[2];

        private int hpd;
        private int hp;
        private int ac;

        public void Evaluate()
        {

        }
    }
}
