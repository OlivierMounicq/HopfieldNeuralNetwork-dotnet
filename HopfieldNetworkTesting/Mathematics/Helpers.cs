using HopfieldNetwork.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopfieldNetworkTesting.Mathematics
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
                            break;
                        }
                    }
                }
            }

            return equal;
        }

        public static bool AreEqualMatrix(double[,] m1, Matrix m2)
        {
            bool equal = true;
           
            if (m1.GetLongLength(0) != m2.RowQuantity || m1.GetLongLength(1) != m2.ColumnQuantity)
            {
                equal = false;
            }

            if (equal)
            {
                for (var idxRow = 0; idxRow < m1.GetLongLength(0); idxRow++)
                {
                    for (var idxCol = 0; idxCol < m1.GetLongLength(1); idxCol++)
                    {
                        if (m1[idxRow, idxCol] != m2[idxRow, idxCol])
                        {
                            equal = false;
                            break;
                        }
                    }
                }
            }

            return equal;
        }

        public static bool AreEqualVector(Vector v1, Vector v2)
        {
            bool equal = true;

            if(v1.Length != v2.Length)
            {
                equal = false;
            }

            if(equal)
            {
                for(var idx = 0; idx < v1.Length; idx++)
                {
                    if (v1[idx] != v2[idx])
                    {
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }

        public static bool AreEqualVector(double[] array, Vector v)
        {
            bool equal = true;

            if(v.Length != array.Length)
            {
                equal = false;
            }

            if(equal)
            {
                for(var idx = 0; idx < array.Length; idx++)
                {
                    if(v[idx] != array[idx])
                    {
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }
    }
}
