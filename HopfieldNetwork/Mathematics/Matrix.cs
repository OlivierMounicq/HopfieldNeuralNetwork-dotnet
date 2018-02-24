using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HopfieldNetwork.Exceptions;

namespace HopfieldNetwork.Mathematics
{
    public class Matrix
    {
        private readonly double[,] matrix;
        private readonly int rowQuantity;
        private readonly int columnQuantity;

        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public int RowQuantity { get { return rowQuantity; } }

        public int ColumnQuantity { get { return columnQuantity; } }

        public Matrix(int rowQuantity, int columnQuantity)
        {
            this.matrix = new double[rowQuantity, columnQuantity];
            this.rowQuantity = rowQuantity;
            this.columnQuantity = columnQuantity;
        }

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
            this.rowQuantity = (int)this.matrix.GetLongLength(0);
            this.columnQuantity = (int)this.matrix.GetLongLength(1);
        }

        public void Initialize()
        {
            this.matrix.Initialize();
        }

        public void Normalize()
        {
            for(var i = 0; i < rowQuantity; i++)
            {
                for (var j = 0; j < columnQuantity; j++)
                {
                    if (this.matrix[i,j] < -1)
                    {
                        this.matrix[i, j] = -1;
                    }

                    if (this.matrix[i, j] > 1)
                    {
                        this.matrix[i, j] = 1;
                    }                 
                }
            }
        }


        public void SetMatrixDiagonalToZero()
        {
            if(rowQuantity != columnQuantity)
            {
                throw new DimensionException(rowQuantity, columnQuantity);
            }

            for (var i = 0; i < rowQuantity; i++)
            {
                this.matrix[i, i] = 0;
            }
        }

        private Matrix Add(Matrix m)
        {
            if(this.rowQuantity != m.rowQuantity || this.columnQuantity != m.ColumnQuantity)
            {
                throw new AdditionDimensionException(this, m);
            }

            var res = new Matrix(this.rowQuantity, this.columnQuantity);

            for (var i = 0; i < rowQuantity; i++)
            {
                for (var j = 0; j < columnQuantity; j++)
                {
                    res[i, j] = this.matrix[i, j] + m[i, j];
                }
            }

            return res;
        }

        private Matrix Multiply(Matrix m)
        {
            if(this.columnQuantity != m.RowQuantity)
            {
                throw new MultiplicationDimensionException(this, m);
            }

            var res = new Matrix(this.rowQuantity, m.ColumnQuantity);
            res.Initialize();

            for(int idxRow = 0; idxRow < this.rowQuantity; idxRow++)
            {
                for(int idxColumnM = 0; idxColumnM < m.ColumnQuantity; idxColumnM++)
                {
                    for(int k = 0; k < this.columnQuantity; k++)
                    {
                        res[idxRow, idxColumnM] += this[idxRow, k] * m[k, idxColumnM];
                    }
                }
            }
           
            return res;
        }

        private Vector MultiplyMatrixByColumnVector(Vector v)
        {
            if(this.ColumnQuantity != v.Length)
            {
                throw new MultiplicationMatrixByVectorDimensionException(string.Format("We cannot multiply the matrix by a row vector. The matrix has {0} columns and the vector has {1} rows", this.ColumnQuantity, v.Length));
            }

            var resultVector = new Vector(this.rowQuantity);

            for(var idxMatrixRow = 0; idxMatrixRow < this.rowQuantity; idxMatrixRow++)
            {
                for(var idxCol = 0; idxCol < this.columnQuantity; idxCol++)
                {
                    resultVector[idxMatrixRow] += this[idxMatrixRow, idxCol] * v[idxCol];
                }
            }

            return resultVector;
        }

        private Vector MultiplyRowVectorByMatrix(Vector v)
        {
            if (this.RowQuantity != v.Length)
            {
                throw new MultiplicationMatrixByVectorDimensionException(string.Format("We cannot multiply the matrix by a row vector. The matrix has {0} columns and the vector has {1} columns", this.RowQuantity, v.Length));
            }

            var resultVector = new Vector(this.ColumnQuantity);

            for(var idxMatrixCol = 0; idxMatrixCol < this.ColumnQuantity; idxMatrixCol++)
            {
                for (var idxCol = 0; idxCol < v.Length; idxCol++)
                {
                    resultVector[idxMatrixCol] += v[idxCol] * this[idxCol, idxMatrixCol];
                }
            }

            return resultVector;
        }


        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return m1.Add(m2);
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return m1.Multiply(m2);
        }

        public static ColumnVector operator *(Matrix m, ColumnVector v)
        {
            return new ColumnVector(m.MultiplyMatrixByColumnVector(v));
        }

        public static RowVector operator *(RowVector v, Matrix m)
        {
            return new RowVector(m.MultiplyRowVectorByMatrix(v));
        }


    }
}
