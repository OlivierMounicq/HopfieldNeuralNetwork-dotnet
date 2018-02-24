using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Mathematics;

namespace HopfieldNetwork.Exceptions
{
    public class MultiplicationMatrixByVectorDimensionException : Exception
    {
        public MultiplicationMatrixByVectorDimensionException(string message)
            :base(message)
        { }
    }
}
