using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsoleApp
{
    class Board
    {
        //Cell is one square to the Board and Grid is 2D array [,] to calculate X and Y location
        public Cell[,] TwoDGrid { get; set; }

        

        //Size (Row*Column)
        public int Size { get; set; }

        public float Difficulty { get; set; }


        //Constructor 
        public Board(int size, float difficulty)
        {
            //initial board size is size
            Size = size;
            Difficulty = difficulty;

            TwoDGrid = new Cell[Size, Size];
            for (int Row = 0; Row < Size; Row++)
            {
                for (int Column = 0; Column < size; Column++)
                {
                    //Recalls the Constructor on Cell library
                    TwoDGrid[Row, Column] = new Cell(Row, Column);
                }
            }
        }
        public Board(int size)
        {
          //When the user did not pick a Difficulty then add an initial difficulty to 10%
            this.Size = size;
            
            this.Difficulty = 0.1f;
        }

        //??
        public Board (float diff)
        {
            //When the user did not pick a Size only then set the initial Size to be 4
            this.Difficulty= diff;
            this.Size = 4;

        }
        public Board()
        {
            //Default Constructor
            //Set the initial difficulty to be 10% and Size 4

            this.Size = 4;
            this.Difficulty= 0.1f;


        }





        //Place bombs on some squares
    public void setupBombs()
        {
            // Random number generator for placement of bombs
            Random random = new Random();

            // Loop (entire grid)
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    
                    TwoDGrid[i, j].Bomb = random.NextDouble() <= Difficulty;
                }
            }

        }

        // Calculate the number of near by bombs
        public void CalcNearByBombs()
        {
            for (int a = 0; a < Size; a++)
            {
                for (int b = 0; b < Size; b++)
                {


                    // North West Direction of current square
                    if (a - 1 >= 0 && b - 1 >= 0 && TwoDGrid[a - 1, b - 1].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // North Direction
                    if (a - 1 >= 0 && TwoDGrid[a - 1, b].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // North East
                    if (a - 1 >= 0 && b + 1 < Size && TwoDGrid[a - 1, b + 1].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // West
                    if (b - 1 >= 0 && TwoDGrid[a, b - 1].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // East
                    if (b + 1 < Size && TwoDGrid[a, b + 1].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // South West
                    if (a + 1 < Size && b - 1 >= 0 && TwoDGrid[a + 1, b - 1].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // South
                    if (a + 1 < Size && TwoDGrid[a + 1, b].Bomb) TwoDGrid[a, b].NearByBombs++;

                    // South East
                    if (a + 1 < Size && b + 1 < Size && TwoDGrid[a + 1, b + 1].Bomb) TwoDGrid[a, b].NearByBombs++;

                }
            }
        }
        
     //Win Condition
     
       internal bool winCondition()
        { 
            
            bool won = true; 

     //Check cell status
     //Always need a nested for loop to check nearbyCells
     //a= row, b = column
     //(initial condition, Define Condition, Increase the value by 1 each time)
            for (int a=0; a < Size;a++)
            {
              for(int b=0; b < Size; b++)
            //If you did not visit the cell and does not have a bomb then you must continue to play
               { 
                    if (TwoDGrid[a, b].Visited== false && TwoDGrid[a,b].Bomb== false)
                    { 
                        won = false;
                 
                     break;
                     }

                     if (TwoDGrid[a,b].Bomb == true && TwoDGrid[a,b].flag == false)

                    {
                        won =false;
                        break;

                    }
                  }
                   if (!won ) break;
            
                   }
                   return won;
                 }
               internal bool loseCondition()
              {
                      bool lost =false;
                    for (int a=0; a <Size; a++)
                     {
                      for (int b=0; b < Size;b++)
                       {
                    // if the grid has a bomb and it is visited Then You will lose
                         if (TwoDGrid[a,b].Bomb && TwoDGrid[a,b].Visited)
                        { lost =true;}
                      }
                      }
                      return lost;
                     }


        //setting up conditions when you flag a location
        internal void Flag(int rowGuess, int colGuess)
        {
            TwoDGrid[rowGuess,colGuess].flag =!(TwoDGrid[rowGuess,colGuess].flag);
        }
    
        internal void Pick(int rowGuess, int colGuess)
        {
            TwoDGrid[rowGuess,colGuess].Visited= true;
        }
    
    
    
    
    
    
    
    
    }
}

