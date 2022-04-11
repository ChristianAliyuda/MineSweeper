using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MineSweeperConsoleApp
  {
    class Program
    {

      
        static void Main(string[] args)
        {
            

            // Board Initial Value
            //Set initial board size = 0
            //Initial Difficulty Level = 0.0f
            int boardSize = 0;
            float DifficultyLevel = 0.0f;

            
            
            
            Boolean validInput = false;

            while (validInput == false)
            {
                validInput = true;
                //The try-catch statement consists of a try block followed by one or more catch clauses, which specify handlers for different exceptions.
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" *============================================*" + "\n" + "||Welcome to MineSweeper Game Created by Chung||" + "\n" + " *============================================*");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Today is {0}", DateTime.Now);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("8 Squares is for Beginner and 16 Squares is for intermediate Player");
                    Console.WriteLine("Please select the size of your board ( 1 to 16 squares?)");
                    boardSize = int.Parse(Console.ReadLine());

                    Console.WriteLine("What percent of cells should contain a bomb?  (0.01 to 0.99)");
                    DifficultyLevel = float.Parse(Console.ReadLine());
                }
                catch
                {
                    validInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is Invalid. Please try again.");
                }
                // If Difficulty Level is less than 1% or greater than 99% then it will be wrong
                {
                    if (DifficultyLevel < 0.01 || DifficultyLevel > 0.99f) validInput = false;
                    if (boardSize < 0 || boardSize > 16) validInput = false;

                    if (validInput == false)
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Something is wrong. Please try again.");
                }
            }

            Board myBoard = new Board(boardSize, DifficultyLevel);


            myBoard.setupBombs();
            myBoard.CalcNearByBombs();
            //printBoard(myBoard);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Are You READYYYY?");
            Console.WriteLine("Let's Gooooo! ! !");
            Console.ReadLine();

        
        
    
          Boolean gameIsWon =false;
          Boolean gameIsLost =false;
          //When game is not lost also game is not won yet
           while (gameIsLost == false && gameIsWon == false)
            { Turn(myBoard);
               gameIsWon = myBoard.winCondition();
               gameIsLost = myBoard.loseCondition();

            if (gameIsLost)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry You Just Lost The Game");
                printBoard(myBoard);

                }

            if (gameIsWon)
            { 
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Congratuations, You Just Won The Game! Now We Can Rule The MineSweeper Galaxy as Father and Son! ! !");
                printBoard(myBoard);
                }
                        
                         
                        
              }
            Console.ReadLine();
         }

        private static void Turn(Board myBoard)
        {

            printBoard2(myBoard);

            //Checking The turn is Valid or not
            Boolean turnIsValid = false;
            while (turnIsValid == false)
            {
                int colGuess = 0;
                int rowGuess = 0;
                turnIsValid = true;
                Console.WriteLine("Prediction Time");
                try
                {
                    Console.WriteLine("Input a row number");
                    rowGuess = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input a column number");
                    colGuess = int.Parse(Console.ReadLine());
                }
                catch
                {
                    turnIsValid = false;
                }

                if (colGuess < 0 || colGuess >= myBoard.Size || rowGuess < 0 || rowGuess >= myBoard.Size)
                {
                    turnIsValid = false;
                }

                if (turnIsValid == false)
                {
                    Console.WriteLine("Wrong Input! Please Try again!");
                }
                string type = "X";
                while (type != "P" && type != "F")
                {

                    Console.WriteLine("Pick or Flag? P or F");
                    type = Console.ReadLine();

                    if (type.Equals("P"))
                        myBoard.Pick(rowGuess, colGuess);
                    else if (type.Equals("F"))
                        myBoard.Flag(rowGuess, colGuess);

                }

            }
        }
       private static void printBoard2(Board myBoard)


        {
            Console.ForegroundColor = ConsoleColor.Blue;

            //Print the board when you select Flag

            Console.WriteLine("Minesweeper Time! ! !");

            for (int a = 0; a < myBoard.Size; a++)
              {

        // Draw this +---+---+---+---+
             drawDivider(myBoard.Size);

                for (int b = 0; b < myBoard.Size; b++)
        {
            // Console.Write(myBoard.TwoDGrid[a, b].IsFlagged.ToString());
            if (myBoard.TwoDGrid[a, b].flag == true)
            {
                Console.Write("| F ");
            }
            else if (myBoard.TwoDGrid[a, b].Visited == false)
            {
                Console.Write("| . ");
            }
            // for each cell, print either a * or a number.
            else if (myBoard.TwoDGrid[a, b].Bomb)
            {
                Console.Write("| * ");
            }
            else
            {
                Console.Write("| ");

                Console.Write(myBoard.TwoDGrid[a, b].NearByBombs + " ");

            }
        }

        // add ending column divider
        Console.WriteLine("|");
             }
    drawDivider(myBoard.Size);
        }





 

         private static void printBoard(Board myBoard)


            {



            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Minesweeper Board");

            for (int a = 0; a < myBoard.Size; a++)
            {

                
                drawDivider(myBoard.Size);

                for (int b = 0; b < myBoard.Size; b++)
                {
                   

                    if (myBoard.TwoDGrid[a, b].Bomb)
                    {
                        //Change my Bomb symbol to Red
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" * ");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("| " + myBoard.TwoDGrid[a, b].NearByBombs + " ");
                    }
                }

              //Change Divider back to Colour Green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("|");
            }
            drawDivider(myBoard.Size);
        }

        private static void drawDivider(int length)
        {
           

            for (int i = 0; i < length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+---");
            }
              Console.WriteLine("+");
        }
    }
}



    
