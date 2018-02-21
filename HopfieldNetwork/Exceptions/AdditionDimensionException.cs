using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Mathematics;

namespace HopfieldNetwork.Exceptions
{
    public class AdditionDimensionException : Exception
    {
        public AdditionDimensionException(Matrix m1, Matrix m2)
            : base(string.Format("The matrix have not the same dimension : matrix 1 : {0}x{1} | matrix 2 : {2}x{3}", m1.RowQuantity, m1.ColumnQuantity, m2.RowQuantity, m2.ColumnQuantity))
        { }
    }
}
