using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HopfieldNetwork.Mathematics;
using HopfieldNetwork.Exceptions;

namespace HopfieldNetworkTesting.Mathematics
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void InstantiateWithDimensionTest()
        {
            var matrix = new Matrix(3, 4);

            var expectedMatrix = new double[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };

            var isEqual = Helpers.AreEqualMatrix(expectedMatrix, matrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void InstantiateWithDoubleDimensionArray()
        {
            var matrix = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 6, 7, 8 }, { 9, 10, 11, 12 } }, true);

            var expectedMatrix = new double[,] { { 1, 2, 3, 4 }, { 4, 6, 7, 8 }, { 9, 10, 11, 12 } };

            var isEqual = Helpers.AreEqualMatrix(expectedMatrix, matrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);
            var m2 = new Matrix(new double[,] { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } }, true);

            var res = m1 * m2;

            var expectedMatrix = new Matrix(new double[,] { { 30, 20 }, { 20, 30 } }, true);

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(MultiplicationDimensionException), "The matrix m1 (2x4) has 4 columns and the matrix m2 (2x4) has 2 rows")]        
        public void MultiplicationExceptionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);
            var m2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);

            var res = m1 * m2;

            var expectedMatrix = new Matrix(new double[,] { { 30, 20 }, { 20, 30 } }, true);
        }

        [TestMethod]
        public void AdditionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);
            var m2 = new Matrix(new double[,] { { 4, 3, 2, 1 }, { 1, 2, 3, 4 } }, true);
            var res = m1 + m2;
            var expectedMatrix = new Matrix(new double[,] { { 5, 5, 5, 5 }, { 5, 5, 5, 5 } }, true);

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(AdditionDimensionException), "The matrix have not the same dimension : matrix 1 : 2x4 | matrix 2 : 4x2")]
        public void AdditionExceptionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);
            var m2 = new Matrix(new double[,] { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } }, true);

            var res = m1 + m2;            
        }

        [TestMethod]
        public void SubstractionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);
            var m2 = new Matrix(new double[,] { { 4, 3, 2, 1 }, { 1, 2, 3, 4 } }, true);
            var res = m1 - m2;
            var expectedMatrix = new Matrix(new double[,] { { -3, -1, 1, 3 }, { 3, 1, -1, -3 } }, true);

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(AdditionDimensionException), "The matrix have not the same dimension : matrix 1 : 2x4 | matrix 2 : 4x2")]
        public void SubtractionExceptionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } }, true);
            var m2 = new Matrix(new double[,] { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } }, true);

            var res = m1 - m2;
        }

        [TestMethod]
        public void MultiplyMatrixByColumnVectorTest()
        {
            var m = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11 ,12 } }, true);
            var v = new ColumnVector(new double[] { 1, 2, 3, 4 });

            var expectedVector = new ColumnVector(new double[] { 30, 70, 110});

            var resVector = m * v;

            var isEqual = Helpers.AreEqualVector(expectedVector, resVector);

            Assert.IsTrue(isEqual);
        }


        [TestMethod]
        [ExpectedException(typeof(MultiplicationMatrixByVectorDimensionException), "We cannot multiply the matrix by a row vector. The matrix has 4 columns and the vector has 5 rows")]
        public void MultiplyMatrixByRowVectorDimensionExceptionTest()
        {
            var m = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } }, true);
            var v = new ColumnVector(new double[] { 1, 2, 3, 4, 5 });

            var resVector = m * v;
        }


        [TestMethod]
        public void MultiplyVectorByMatrixTest()
        {
            var m = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } }, true);
            var v = new RowVector(new double[] { 1, 2, 3 });

            var expectedVector = new RowVector(new double[] { 38, 44, 50, 56 });

            var resVector = v * m;

            var isEqual = Helpers.AreEqualVector(expectedVector, resVector);

            Assert.IsTrue(isEqual);
        }
    }
}
