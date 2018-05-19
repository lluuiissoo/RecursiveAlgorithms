using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodFill
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8] {
                { 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1, 0, 0},
                { 1, 0, 0, 1, 1, 0, 1, 1},
                { 1, 2, 2, 2, 2, 0, 1, 0},
                { 1, 1, 1, 2, 2, 0, 1, 0},
                { 1, 1, 1, 2, 2, 2, 2, 0},
                { 1, 1, 1, 1, 1, 2, 1, 1},
                { 1, 1, 1, 1, 1, 2, 2, 1},
            };

            Print2DArray(matrix);

            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                    Console.Write("Enter x:"); int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter y:"); int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter color:"); int color = Convert.ToInt32(Console.ReadLine());
                    Fill(matrix, x, y, color);
                    Print2DArray(matrix);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            //Console.ReadLine();
        }

        public static void Print2DArray<T>(T[,] matrix)
        {
            Console.Write("------------------------------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    ConsoleColor pixelColor = ConsoleColor.White;
                     
                    switch (matrix[i, j].ToString()) {
                        case "1":
                            pixelColor = ConsoleColor.Blue;
                            break;
                        case "2":
                            pixelColor = ConsoleColor.Red;
                            break;
                        case "3":
                            pixelColor = ConsoleColor.Yellow;
                            break;
                    }


                    ConsoleColor currentForeground = Console.ForegroundColor;
                    Console.ForegroundColor = pixelColor;
                    Console.Write(matrix[i, j] + "\t");
                    Console.ForegroundColor = currentForeground;
                }
                Console.WriteLine();
            }
            Console.Write("------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public static void Fill(int[,] matrix, int x, int y, int color)
        {
            int currentC = matrix[x, y];
            matrix[x, y] = color;
            //Print2DArray(matrix);

            //Up
            if ((x > 0) && (matrix[x - 1, y] == currentC))
                Fill(matrix, x - 1, y, color);

            //Down
            if ((x < matrix.GetLength(0)-1) && (matrix[x + 1, y] == currentC))
                Fill(matrix, x + 1, y, color);

            //Left
            if ((y > 0) && (matrix[x, y - 1] == currentC))
                Fill(matrix, x, y - 1, color);

            //Right
            if ((y < matrix.GetLength(1) - 1) && (matrix[x, y + 1] == currentC))
                Fill(matrix, x, y + 1, color);

        }
    }
}
