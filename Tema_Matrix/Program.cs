using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_Matrix
{
    class Program
    {
        
        
            static readonly Random rnd = new Random();

            static void Main()
            {
                var matrix1 = new Matrix<int>(3, 3,
                    1, 2, 0,
                    0, 1, 1,
                    2, 0, 1);

                var matrix2 = new Matrix<int>(3, 3);

                for (uint row = 0; row < matrix2.Rows; row++)
                    for (uint col = 0; col < matrix2.Columns; col++)
                        matrix2[row, col] = rnd.Next(10);

                Console.WriteLine("First Matrix ({0}x{1}) is:", matrix1.Rows, matrix1.Columns);
                Console.WriteLine(matrix1);

                Console.WriteLine("Second Matrix ({0}x{1}) is:", matrix2.Rows, matrix2.Columns);
                Console.WriteLine(matrix2);

                Console.WriteLine("Аccumulation of the Matrices:");
                Console.WriteLine(matrix1 + matrix2);

                Console.WriteLine("Subtraction of the Matrices:");
                Console.WriteLine(matrix1 - matrix2);

                Console.WriteLine("Multiplication of the Matrices:");
                Console.WriteLine(matrix1 * matrix2);

                Console.WriteLine("First matrix: {0}", matrix1 ? "Non-empty!" : "Empty!");
                Console.WriteLine("New matrix: {0}\n", new MatrixOperations<double>(1, 1) ? "Non-empty!" : "Empty!");
            }
        
    }
}
