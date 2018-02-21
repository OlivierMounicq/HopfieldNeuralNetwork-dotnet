using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HopfieldNetwork.Mathematics;
using HopfieldNetwork.Exceptions;

namespace HopfieldNetworkTesting
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void MultiplicationTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } });
            var m2 = new Matrix(new double[,] { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } });

            var res = m1 * m2;

            var expectedMatrix = new Matrix(new double[,] { { 30, 20 }, { 20, 30 } });

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);

        }

        [TestMethod]
        [ExpectedException(typeof(MultiplicationDimensionException), "The matrix m1 (2x4) has {4} columns and the matrix m2 (2x4) has {2} rows")]        
        public void MultiplicationExceptionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } });
            var m2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } });

            var res = m1 * m2;

            var expectedMatrix = new Matrix(new double[,] { { 30, 20 }, { 20, 30 } });
        }

        [TestMethod]
        public void AdditionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } });
            var m2 = new Matrix(new double[,] { { 4, 3, 2, 1 }, { 1, 2, 3, 4 } });
            var res = m1 + m2;
            var expectedMatrix = new Matrix(new double[,] { { 5, 5, 5, 5 }, { 5, 5, 5, 5 } });

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(AdditionDimensionException), "The matrix have not the same dimension : matrix 1 : {2}x{4} | matrix 2 : {4}x{2}")]
        public void AdditionExceptionTest()
        {
            var m1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 4, 3, 2, 1 } });
            var m2 = new Matrix(new double[,] { { 1, 4 }, { 2, 3 }, { 3, 2 }, { 4, 1 } });

            var res = m1 + m2;            
        }
    }
}
