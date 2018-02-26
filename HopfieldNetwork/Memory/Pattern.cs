using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Mathematics;

namespace HopfieldNetwork.Memory
{
    public class Pattern : Matrix
    {
        public readonly string Name;

        public Pattern(string name, int rowQuantity, int columnQuantity)
            : base(rowQuantity, columnQuantity)
        {
            this.Name = name;
        }
       
        public Pattern(string name, double[,] pattern)
            : base(pattern, true)
        {
            this.Name = name;
        }


        public Matrix GetWeightMatrix()
        {
            var weightMatrix = this.GetVector().Transpose() * this.GetVector();

            return weightMatrix;
        }

        public Pattern GetNewRandomPattern(string patternName)
        {
            var rdm = new Random();
            var randomIdxRow = rdm.Next(this.RowQuantity - 1);
            var randomIdxCol = rdm.Next(this.ColumnQuantity - 1);

            var matrix = this.Clone();

            if(matrix[randomIdxRow, randomIdxCol] == 1)
            {
                matrix[randomIdxRow, randomIdxCol] = -1;
            }
            else
            {
                matrix[randomIdxRow, randomIdxCol] = 1;
            }

            var modifiedPattern = new Pattern(patternName, matrix.NestedArray);

            return modifiedPattern;
        }
        
        internal RowVector GetVector()
        {
            var vector = new RowVector(this.RowQuantity * this.ColumnQuantity);

            for(var idxRow = 0; idxRow < this.RowQuantity; idxRow++)
            {
                for(var idxCol =0; idxCol < this.ColumnQuantity; idxCol++)
                {
                    vector[(idxRow * this.ColumnQuantity) + idxCol] = this[idxRow, idxCol];
                }
            }

            return vector;   
        }
    }
}
