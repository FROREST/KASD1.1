using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        string[] lines = File.ReadAllLines("/Users/liga/Desktop/ConsoleApp1/ConsoleApp1/input.txt");
        int n = int.Parse(lines[0]); 
        double[,] G = new double[n, n]; 
        double[] x = new double[n]; 

        
        for (int i = 0; i < n; i++)
        {
            string[] values = lines[i + 1].Split();
            for (int j = 0; j < n; j++)
            {
                G[i, j] = double.Parse(values[j]);
            }
        }

        
        string[] vectorValues = lines[n + 1].Split();
        for (int i = 0; i < n; i++)
        {
            x[i] = double.Parse(vectorValues[i]);
        }

        
        if (!IsSymmetric(G, n))
        {
            Console.WriteLine("Матрица G не симметрична.");
            return;
        }

        
        double length = CalculateLength(G, x, n);
        Console.WriteLine($"Длина вектора: {length}");
    }

    static bool IsSymmetric(double[,] matrix, int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (matrix[i, j] != matrix[j, i])
                {
                    return false;
                }
            }
        }
        return true;
    }

    static double CalculateLength(double[,] G, double[] x, int n)
    {
        double sum = 0.0;

        
        for (int i = 0; i < n; i++)
        {
            double temp = 0.0;
            for (int j = 0; j < n; j++)
            {
                temp += G[i, j] * x[j];
            }
            sum += x[i] * temp;
        }

        return Math.Sqrt(sum);
    }
}