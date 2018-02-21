using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Mathematics;

namespace HopfieldNetwork.Exceptions
{
    public class MultiplicationDimensionException : Exception
    {
        public MultiplicationDimensionException(Matrix m1, Matrix m2)
            : base(string.Format("The matrix m1 ({0}x{1}) has {1} columns and the matrix m2 ({2}x{3}) has {2} rows", m1.RowQuantity, m1.ColumnQuantity, m2.RowQuantity, m2.ColumnQuantity))
        { }
    }
}
