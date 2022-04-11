using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsoleApp
{

    //Basic Property for a Cell: Column, Row, Is The Cell visited/flag/live bomb/live neighbours (How many neighbours are live bombs)
    class Cell
    {
        //Making sure The Cell property is accessable to other library etc
        public int Column { get; set; }
        public int Row { get; set; }
        public int NearByBombs { get; set; }
        public bool Visited { get; set; }
        public bool flag { get; set; }
        public bool Bomb { get; set; }

        public Cell()
        {
            //initial condition [constructor]
            this.Column = -1;
            this.Row = -1;
            this.NearByBombs = 0;
            this.Visited = false;
            this.flag = false;
            this.Bomb = false;


        }
        //Method overloading
        //Same name different parameters

        //Using x and y to find an object location
        //a is row, b is column [row is like Y direction while colum is like X direction]
        //Constructor is Needed For the Grid 
        public Cell(int a, int b)
        {
            a = Row;
            b = Column;
            NearByBombs = 0;
            Visited = false;
            flag = false;
            Bomb = false;
                
                
                
         }



     }
}
