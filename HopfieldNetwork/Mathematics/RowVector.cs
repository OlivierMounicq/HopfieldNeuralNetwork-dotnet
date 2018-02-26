using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Exceptions;

namespace HopfieldNetwork.Mathematics
{
    public class RowVector : Vector
    {
        public RowVector(Vector v)
            : base(v)
        { }

        public RowVector(int length)
            : base(length)
        { }

        public RowVector(double[] vector) :
            base(vector)
        { }

        public ColumnVector Transpose()
        {
            return new ColumnVector(this);
        }

        public static double operator *(RowVector v1, RowVector v2)
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

        public static double operator *(RowVector v1, ColumnVector v2)
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
    }
}
