using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Exceptions;

namespace HopfieldNetwork.Mathematics
{
    public class ColumnVector : Vector
    {
        public ColumnVector(Vector v)
            : base(v)
        { }
            
        public ColumnVector(int length)
            :base(length)
        {            
        }

        public ColumnVector(double[] vector)
            :base(vector)
        {            
        }

        public RowVector Transpose()
        {
            return new RowVector(this);
        }

        public static Matrix operator *(ColumnVector v1, RowVector v2)
        {
            return v1.Multiply(v2);
        }

        public static double operator *(ColumnVector v1, ColumnVector v2)
        {
            if (v1.Length != v2.Length)
            {
                throw new MultiplicationVectorDimensionException(v1, v2);
            }

            double result = 0;

            for (var idx = 0; idx < v1.Length; idx++)
            {
                result += v1[idx] * v2[idx];
            }

            return result;
        }

        private Matrix Multiply(Vector v)
        {
            var matrix = new Matrix(this.Length, v.Length);

            for (var idxRow = 0; idxRow < this.Length; idxRow++)
            {
                for (var idxCol = 0; idxCol < v.Length; idxCol++)
                {
                    matrix[idxRow, idxCol] = this[idxRow] * v[idxCol];
                }
            }

            return matrix;
        }
    }
}
