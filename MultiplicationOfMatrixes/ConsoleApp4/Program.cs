using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int Columns = 1000;
            int Rows = 1000;
            int NumberOfArrays = 1000;
            int ElementsInArray = 1000;
            int[,] FirstArray = new int[Rows, Columns];
            int[,] SecondArray = new int[Rows, Columns];
            int[][] ThirdArray = new int[NumberOfArrays][];
            int[][] FourthArray = new int[NumberOfArrays][];
            long DurationOfTwoDecimalMatrix;
            long DurationOfTeethMatrix;
            Stopwatch sw = new Stopwatch();
            Random RandomNumber = new Random();
            FirstArray = TwoDimensionalFirstArray(Columns, Rows, FirstArray, RandomNumber);
            SecondArray = TwoDimensionalSecondArray(Columns, Rows, SecondArray, RandomNumber);

            ThirdArray = TeethFirstArray(NumberOfArrays, ElementsInArray, ThirdArray, RandomNumber);
            FourthArray = TeethSecondArray(NumberOfArrays, ElementsInArray, FourthArray, RandomNumber);

            DurationOfTwoDecimalMatrix = MultiplicationOfTwoDecimalMatrix(FirstArray, SecondArray, Rows, Columns, sw);            
            DurationOfTeethMatrix = MultiplicationOfTeethMatrix(ThirdArray, FourthArray, ElementsInArray, NumberOfArrays, sw);

            PrintResults(DurationOfTeethMatrix, DurationOfTwoDecimalMatrix, Columns, NumberOfArrays);
        }

        static int[,] TwoDimensionalFirstArray(int Columns, int Rows, int[,] FirstArray, Random RandomNumber)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int Number = RandomNumber.Next(Environment.TickCount);
                    FirstArray[i, j] = Number;
                }
            }
            return FirstArray;
        }

        static int[,] TwoDimensionalSecondArray(int Columns, int Rows, int[,] SecondArray, Random RandomNumber)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    int Number = RandomNumber.Next(Environment.TickCount);
                    SecondArray[i, j] = Number;
                }
            }
            return SecondArray;
        }

        static int[][] TeethFirstArray(int NumberOfArrays, int ElementsInArray, int[][] ThirdArray, Random RandomNumber)
        {          
                for (int i = 0; i < NumberOfArrays; i++)
                {
                ThirdArray[i] = new int[ElementsInArray];

                for (int j = 0; j < ElementsInArray; j++)
                    {
                    int Number = RandomNumber.Next(Environment.TickCount);
                    ThirdArray[i][j] = Number;
                    }
                }
            return ThirdArray;
        }

        static int[][] TeethSecondArray(int NumberOfArrays, int ElementsInArray, int[][] FourthArray, Random RandomNumber)
        {
           for (int i = 0; i < NumberOfArrays; i++)
            {
                FourthArray[i] = new int[ElementsInArray];

                for (int j = 0; j < ElementsInArray; j++)
                {
                    int Number = RandomNumber.Next(Environment.TickCount);
                    FourthArray[i][j] = Number;
                }
            }
            return FourthArray;
        }

        static long MultiplicationOfTwoDecimalMatrix(int[,] FirstArray, int[,] SecondArray, int Rows, int Columns, Stopwatch sw)
        {
            int[,] FinalArray = new int[Rows, Columns];
            sw.Start();
            for (int i = 0; i < Rows; i++)
            {                              
                for (int j = 0; j < Columns; j++)
                {
                    for (int k = 0; k < Rows; k++)
                    {
                        FinalArray[i, j] += FirstArray[i, k] * SecondArray[j, k];
                    }
                }                
            }
            sw.Stop();
            long duration = sw.ElapsedMilliseconds;
            return duration;           
        }

        static long MultiplicationOfTeethMatrix(int[][] ThirdArray, int[][] FourthArray, int ElementsInArray, int NumberOfArrays, Stopwatch sw)
        {
            int[][] FinalArray = new int[NumberOfArrays][];
            sw.Start();
            for (int i = 0; i < NumberOfArrays; i++)
            {
                FinalArray[i] = new int[NumberOfArrays];
                for (int j = 0; j < ElementsInArray; j++)
                {
                    for (int k = 0; k < NumberOfArrays; k++)
                    {
                        FinalArray[i][j] += ThirdArray[i][k] * FourthArray[j][k];
                    }
                }
            }
            sw.Stop();
            long duration = sw.ElapsedMilliseconds;
            return duration;
        }

        static void PrintResults(long DurationOfTeethMatrix, long DurationOfTwoDecimalMatrix, int Columns, int NumberOfArrays)
        {
            Console.WriteLine($"Время умножения двумерных массивов = {DurationOfTwoDecimalMatrix}");
            double PowerGFlopsTD = ((2* (Math.Pow(Columns, 3))) /(DurationOfTwoDecimalMatrix/1000));
            Console.WriteLine($"Производительность в ГФлопс = {PowerGFlopsTD}");
            Console.WriteLine($"Время умножения массива массивов = {DurationOfTeethMatrix}");
            double PowerGFlopsT = ((2 * (Math.Pow(NumberOfArrays, 3))) / (DurationOfTwoDecimalMatrix/1000)); 
            Console.WriteLine($"Производительность в ГФлопс = {PowerGFlopsT}");
            Console.ReadKey();
        }
    }
}
