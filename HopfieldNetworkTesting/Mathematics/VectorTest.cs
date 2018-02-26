using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HopfieldNetwork.Mathematics;
using HopfieldNetwork.Exceptions;

namespace HopfieldNetworkTesting.Mathematics
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void VectorMultiplicationTest()
        {
            var v1 = new ColumnVector(new double[] { 1, 2, 3, 4 });
            var v2 = new RowVector(new double[] { 5, 6, 7, 8 });

            var expectedMatrix = new Matrix(new double[4, 4] { { 5, 6, 7, 8 }, { 10, 12, 14, 16 }, { 15, 18, 21, 24 }, { 20, 24, 28, 32 } }, true);
            
            var res = v1 * v2;

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void VectorMultiplicationWithDifferentLengthTest()
        {
            var v1 = new ColumnVector(new double[] { 1, 2, 3 });
            var v2 = new RowVector(new double[] { 4, 5, 6, 7, 8 });

            var expectedMatrix = new Matrix(new double[3, 5] { { 4, 5, 6, 7, 8 }, { 8, 10, 12, 14, 16 }, { 12, 15, 18, 21, 24 } }, true);

            var res = v1 * v2;

            var isEqual = Helpers.AreEqualMatrix(res, expectedMatrix);

            Assert.IsTrue(isEqual);
        }
    }
}
