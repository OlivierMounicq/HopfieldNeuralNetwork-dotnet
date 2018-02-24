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

        public Vector(Vector v)
        {
            this.vector = new double[v.Length];

            for(var idx = 0; idx < v.Length; idx++)
            {
                this.vector[idx] = v[idx];
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
    }
}
