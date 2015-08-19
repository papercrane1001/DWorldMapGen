using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dice
    {
        private int number;
        private int type;
        private int mod;
        private Random rand = new Random();
        private int total = 0;

        public Dice() { }

        public Dice(int num, int d)
        {
            number = num;
            type = d;
            mod = 0;
        }

        public Dice(int num, int d, int modifier)
        {
            number = num;
            type = d;
            mod = modifier;
        }
        public int Roll()
        {
            total = 0;
            for (int i = 0; i < number; i++)
            {
                total += rand.Next(1, type);
            }
            total += mod;
            return 0;
        }
    }
}
