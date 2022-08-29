using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodewarsNotepad
{
    public class ConwayLife
    {
        private static bool _debug = false;

        public static int[,] GetGeneration(int[,] cells, int generation)
        {
            var actualBoard = cells;
            var nextGenerationBoard = new int[cells.GetLength(0), cells.GetLength(1)];
            Console.WriteLine($"_________#$%#$%#$%#$%#$%#$%#$%#$% GetGeneration start #$%#$%#$%#$%#$%#$%#$%#$%_________" +
                $"\nGeneration number target: {generation}");
            PrintBoard(actualBoard, "INPUT table");

            for (int i = 0; i < generation; i++)
            {
                if (_debug) Console.WriteLine($"###################### {i+1} ######################" +
                    $"\nMain loop for. Counting generation {i+1}");
                ComputeFutureBoard(actualBoard, nextGenerationBoard);
                actualBoard = nextGenerationBoard;
            }

            PrintBoard(actualBoard, "OUTPUT table");
            if (_debug) Console.WriteLine($"Size of array actualBoard is: {actualBoard.GetLength(0)},{actualBoard.GetLength(1)}");
            return actualBoard;
        }

        private static void PrintBoard(int[,] board, string header)
        {
            Console.WriteLine(header);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++) Console.Write($"{board[i, j]} ");
                Console.Write("\n");
            }
        }

        public static void ComputeFutureBoard(int[,] actualBoard, int[,] nextGenerationBoard)
        {
            for (int j = 0; j < nextGenerationBoard.GetLength(0); j++)
            {
                for (int k = 0; k < nextGenerationBoard.GetLength(1); k++)
                {
                    var neighbours = CountNeighbours(j, k, actualBoard);
                    nextGenerationBoard[j, k] = GetCellValueAtNextGeneration(actualBoard[j, k], neighbours);
                    if (_debug) Console.WriteLine($"futureBoard[{j},{k}] = {nextGenerationBoard[j, k]}.");
                }
            }
        }

        public static int CountNeighbours(int i, int j, int[,] actualBoard)
        {
            int iMax = actualBoard.GetLength(0) - 1;
            int jMax = actualBoard.GetLength(1) - 1;
            int neighbours = 0;

            neighbours += (i > 0 && j > 0) ? actualBoard[i - 1, j - 1] : 0;
            neighbours += ((i > 0) ? actualBoard[i - 1, j] : 0);
            neighbours += ((i > 0 && j < jMax) ? actualBoard[i - 1, j + 1] : 0);
            neighbours += ((j > 0) ? actualBoard[i, j - 1] : 0);
            neighbours += ((j < jMax) ? actualBoard[i, j + 1] : 0);
            neighbours += ((i < iMax && j > 0) ? actualBoard[i + 1, j - 1] : 0);
            neighbours += ((i < iMax) ? actualBoard[i + 1, j] : 0);
            neighbours += ((i < iMax && j < jMax) ? actualBoard[i + 1, j + 1] : 0);

            return neighbours;
        }

        public static int GetCellValueAtNextGeneration(int cell, int numberOfNeighbours)
        {
            int ret;
            if (cell == 1 && numberOfNeighbours >= 2 && numberOfNeighbours <= 3) ret = 1;
            else if (cell == 0 && numberOfNeighbours == 3) ret = 1;
            else ret = 0;
            
            if(_debug) Console.WriteLine($"Cell start value = {cell}, number of neighbours = {numberOfNeighbours}");
            
            return ret;
        }

    }
}

//Task description
//Given a 2D array and a number of generations, compute n time steps of Conway's Game of Life.

//The rules of the game are:

//    Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
//    Any live cell with more than three live neighbours dies, as if by overcrowding.
//    Any live cell with two or three live neighbours lives on to the next generation.
//    Any dead cell with exactly three live neighbours becomes a live cell.

//Each cell's neighborhood is the 8 cells immediately around it (i.e. Moore Neighborhood). The universe is infinite in both the x and y dimensions and all cells are initially dead - except for those specified in the arguments. The return value should be a 2d array cropped around all of the living cells. (If there are no living cells, then return [[]].)

//For illustration purposes, 0 and 1 will be represented as ░░ and ▓▓ blocks respectively (PHP, C: plain black and white squares). You can take advantage of the htmlize function to get a text representation of the universe, e.g.:

//console.log(htmlize(cells));

/* Please note that the htmlize function for C# currently isn't working
                properly. I tested it on rextester.com and the code worked as expected,
                but for some reason on codewars it isn't. When I find a solution to
                the issue I will update the function. */


/*
My notes before start

n - neighbours number
s - state (live/died)
Rules:
1. if (s==1 && n<2) s=0 
2. if (s==1 && n==2 || s==1 && n==3) s=1
3. if (s==1 && n>3) s=0
4. if (s==0 && n==3) s=1

Simplified:
if (s==1 && n==2 || s==1 && n==3) s=1;
else if (s==0 && n==3) s=1;
else s=0;

 */