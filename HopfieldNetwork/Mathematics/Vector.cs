using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Exceptions;

namespace HopfieldNetwork.Mathematics
{
    public class Vector
    {
        private readonly double[] vector;

        public double this[int i]
        {
            get { return vector[i]; }
            set { vector[i] = value; }
        }

        public int Length
        {
            get
            {
                return this.vector.Length;
            }
        }


        public Vector(int length)
        {
            this.vector = new double[length];
        }

        public Vector(double[] vector)
        {
            this.vector = vector;
        }
                    
        private Matrix Multiply(Vector v)
        {
            if(this.Length != v.Length)
            {
                throw new MultiplicationVectorDimensionException(this, v);
            }

            var matrix = new Matrix(this.Length, this.Length);

            for(var idxRow = 0; idxRow < this.Length; idxRow++)
            {
                for(var idxCol = 0; idxCol < v.Length; idxCol++)
                {
                    matrix[idxRow, idxCol] = this[idxRow] * v[idxCol];
                }                
            }

            return matrix;
        }


        public static Matrix operator *(Vector v1, Vector v2)
        {
            return v1.Multiply(v2);
        }

        public double ScalarProduct(Vector v1, Vector v2)
        {
            if (v1.Length != v2.Length)
            {
                throw new MultiplicationVectorDimensionException(v1,v2);
            }

            double result = 0;

            for(var idx = 0; idx < v1.Length; idx++)
            {
                result += v1[idx] * v2[idx];
            }

            return result;
        }


    }
}
