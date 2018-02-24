using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Mathematics;

namespace HopfieldNetwork.Exceptions
{
    public class MultiplicationVectorDimensionException : Exception        
    {
        public MultiplicationVectorDimensionException(Vector v1, Vector v2)
            :base(string.Format("The vector have not the same length ( length of V1 : {0}, length of V2 : {1} )", v1.Length, v2.Length))
        { }
    }
}
