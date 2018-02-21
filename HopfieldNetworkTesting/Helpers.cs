using HopfieldNetwork.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldNetworkTesting
{
    internal class Helpers
    {
        public static bool AreEqualMatrix(Matrix m1, Matrix m2)
        {
            bool equal = true;

            if(m1.RowQuantity != m2.RowQuantity || m1.ColumnQuantity != m2.ColumnQuantity)
            {
                equal = false;
            }

            if(equal)
            {
                for (var idxRow = 0; idxRow < m1.RowQuantity; idxRow++)
                {
                    for(var idxCol = 0; idxCol < m1.ColumnQuantity; idxCol++)
                    {
                        if (m1[idxRow, idxCol] != m2[idxRow, idxCol])
                        {
                            equal = false;
                        }
                    }
                }
            }

            return equal;
        }
    }
}
