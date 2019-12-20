using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Ora2
{
    public class Matrix
    {
        int i, j, m, n;
        int[,] a = new int[20, 20];
        int[,] c = new int[20, 20];
        public void getmatrix()
        {
            Console.WriteLine("Enter the Number of Rows : ");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Number of Columns : ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Elements");
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Given Matrix");

            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    Console.Write("\t{0}", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        // Find Sum of the Elements of each Column of the Given Matrix
        public  void Sum()
        {
            int[] array = new int[20];

            int sumCol;
            for (int i = 1; i <= 4; i++)
            {
                sumCol = 0;
                for (int j = 1; j <= 4; j++)
                {
                    sumCol = sumCol + a[j, i];
                }
                Console.WriteLine("{0} Column Sum : {1}", i, sumCol);
            }


        }
        // Interchange any 2 Columns of Matrix
        public  void Interchange()
        {

            int m = 2;
            int n = 3;
            int aux;
            for (int i = 1; i <= n; i++)
            {
                aux = 0;
                for (int j = 1; j <= m; j++)
                {
                    aux = a[j, i - 1];
                    a[j, i - 1] = a[i, j - 1];
                    a[i, j - 1] = aux;
                }
                Console.WriteLine("{0} Column Sum : {1}", i, aux);
            }

        }


    }
}

