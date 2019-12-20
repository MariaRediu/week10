using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tema_Matrix
{
    
        public class MatrixOperations<T>
        {
            // Constan Field
            private readonly T[,] matrix = null;

            // Constructor
            public MatrixOperations(uint rows, uint columns, params T[] elements)
            {
                if (rows * columns != elements.Length && elements.Length != 0)
                    throw new ArgumentException();

                this.matrix = new T[rows, columns];
                this.Rows = rows;
                this.Columns = columns;

                if (elements.Length > 0)
                    Buffer.BlockCopy(elements, 0, this.matrix, 0, (int)(rows * columns * Marshal.SizeOf(typeof(T))));
            }

            // Properties
            public uint Rows { get; set; }

            public uint Columns { get; set; }

            // Indexer
            public T this[uint row, uint col]
            {
                get
                {
                    return this.matrix[row, col];
                }
                set
                {
                    this.matrix[row, col] = value;
                }
            }

            // Override method ToString() to print appropriately matrix elements 
            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                for (int row = 0; row < this.Rows; row++)
                {
                    for (int col = 0; col < this.Columns; col++)
                        result.AppendFormat("{0,4}", this.matrix[row, col]);
                    result.AppendLine();
                }

                return result.ToString();
            }

            // (m1 + m2)
            public static MatrixOperations<T> operator +(MatrixOperations<T> matrix1, MatrixOperations<T> matrix2)
            {
                return AdditionSubtraction(matrix1, matrix2, true);
            }

            //  (m1 - m2)
            public static MatrixOperations<T> operator -(MatrixOperations<T> matrix1, MatrixOperations<T> matrix2)
            {
                return AdditionSubtraction(matrix1, matrix2, false);
            }

            private static MatrixOperations<T> AdditionSubtraction(MatrixOperations<T> matrix1, MatrixOperations<T> matrix2, bool op) // true - addition
            {
                if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                    throw new InvalidOperationException("Invalid operation! Matrices must be of one and same size...");

            MatrixOperations<T> result = new MatrixOperations<T>(matrix1.Rows, matrix1.Columns);

                for (uint row = 0; row < result.Rows; row++)
                    for (uint col = 0; col < result.Columns; col++)
                        result[row, col] = matrix1[row, col] + (op ? matrix2[row, col] : -(dynamic)matrix2[row, col]);

                return result;
            }

            //  (m1 * m2)
            public static MatrixOperations<T> operator *(MatrixOperations<T> matrix1, MatrixOperations<T> matrix2)
            {
            MatrixOperations<T> result = new MatrixOperations<T>(matrix1.Rows, matrix2.Columns);

                for (uint row = 0; row < result.Rows; row++)
                    for (uint col = 0; col < result.Columns; col++)
                        for (uint k = 0; k < matrix1.Columns; k++) 
                            result[row, col] += (dynamic)matrix1[row, k] * matrix2[k, col];

                return result;
            }

            public static bool operator true(MatrixOperations<T> matrix)
            {
                return BooleanOperator(matrix, true);
            }

            public static bool operator false(MatrixOperations<T> matrix)
            {
                return BooleanOperator(matrix, false);
            }


            private static bool BooleanOperator(MatrixOperations<T> matrix, bool op)
            {
                foreach (T element in matrix.matrix)
                    if (!element.Equals(default(T)))
                        return op;

                return !op;
            }
        }
    
}
