using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Creature
    {
        private List<Item> itemsHeld;

        private int hd;
        private int dX;
        private int mod;
        private int floor;
        private int[] location = new int[2];

        private int hpd;
        private int hp;
        private int ac;
        public Creature() { }

        public Creature(int hitDice, int dBlank, int modifier, int healthDice, int armorClass, int[] xyCoord, int floornum)
        {
            hd = hitDice;
            dX = dBlank;
            mod = modifier;
            location[0] = xyCoord[0];
            location[1] = xyCoord[1];
            hpd = healthDice;
            floor = floornum;
            ac = armorClass;
        }

        //public Creature(int hitDice, int dBlank, int modifier, int healthPts, int armorClass, int[] xyCoord, int floornum)
        //{
        //    hd = hitDice;
        //    dX = dBlank;
        //    mod = modifier;
        //    location[0] = xyCoord[0];
        //    location[1] = xyCoord[1];
        //    hp = healthPts;
        //    floor = floornum;
        //    ac = armorClass;
        //}

        public void Die()
        {
            //this.location[0]
            
        }
    }
}
