using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldNetwork.Exceptions
{
    public class DimensionException : Exception
    {
        public DimensionException(int rowQuantity, int columnQuantity)
            :base(string.Format("The row quantity ({0}) is not equal to the column quantity ({1}) ", rowQuantity, columnQuantity))
        {}        
    }
}
