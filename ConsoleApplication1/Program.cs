using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
//using Excel = Microsoft.Office.Interop.Excel;


namespace ConsoleApplication1
{


    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Excel.Application iDunno = new Excel.Application();
            Excel.Workbook trial1;
            Excel.Worksheet trial1sheet1;
            object misValue = System.Reflection.Missing.Value;
            trial1 = iDunno.Workbooks.Add(misValue);
            trial1sheet1 = (Excel.Worksheet)iDunno.Worksheets.get_Item(1);
            //trial1sheet1.Cells[1, 1] = "wat";
            */
            
            

            //Console.ReadLine();

            Dungeon dungeoninst;
            Random seed_not = new Random();
            int seed = seed_not.Next();
            //Console.WriteLine(seed);
            Console.WriteLine("Size of map: x","");
            //int xmap = Int32.Parse(Console.ReadLine());
            int xmap = 40;
            //Console.WriteLine(xmap);
            Console.WriteLine("Size of map: y", "");
            //int ymap = Int32.Parse(Console.ReadLine());
            int ymap = 40;
            //Console.WriteLine("Wall hits until Quit:", "");
            //int loops = Int32.Parse(Console.ReadLine());
            int loops = 1000;
            Console.WriteLine("Loops until quit:", "");
            //int quit = Int32.Parse(Console.ReadLine());
            int quit = 500;
            Floor tempfloor = new Floor(xmap, ymap, loops, quit, 0);


            string[] tempLines = new string[40];
            
            for (int i = 0; i < ymap; i++)
            {
                for (int j = 0; j < xmap; j++)
                {
                    if (tempfloor.Tilemap[j, i].Wall)
                    {
                        Console.Write(1);
                        //trial1sheet1.Cells[j+1, i+1] = 1;
                        tempLines[i] = tempLines[i] + 1;

                    }

                    else
                    {
                        Console.Write(0);
                        //trial1sheet1.Cells[j+1, i+1] = 0;
                        tempLines[i] = tempLines[i] + 0;
                    }
                }
                Console.WriteLine("");
            }
            
            //iDunno.Quit();

            //System.IO.File.WriteAllLines(@"C:\Users\Nostariel\Desktop\New folder\WriteLines2.txt", tempLines);

            Interface inter = new Interface();
            inter.ShowDialog();


            Console.ReadLine();
            
        }
        static void Initialize(Dungeon dungeon, int xmap, int ymap, int CR)
        {
            //dungeon.Floor
        }
        

    }
}
