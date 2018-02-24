using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HopfieldNetwork.Mathematics;
using HopfieldNetwork.Exceptions;

namespace HopfieldNetworkTesting.Mathematics
{
    [TestClass]
    public class RowVectorTest
    {
        [TestMethod]
        public void InstantiateRowVectorWithValueTest()
        {
            var vector = new RowVector(4);

            var expectedValues = new double[] { 0, 0, 0, 0 };

            bool isEqual = Helpers.AreEqualVector(expectedValues, vector);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void InstantiateRowVectorWithArray()
        {
            var vector = new RowVector(new double[] { 1, 2, 3, 4 });

            var expectedValues = new double[] { 1, 2, 3, 4 };

            bool isEqual = Helpers.AreEqualVector(expectedValues, vector);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void InstantiateRowVectorWithVector()
        {
            var vector = new RowVector(new Vector(new double[] { 1, 2, 3, 4 }));

            var expectedValues = new double[] { 1, 2, 3, 4 };

            bool isEqual = Helpers.AreEqualVector(expectedValues, vector);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void ScalarProductTest()
        {
            var v1 = new RowVector(new double[] { 1, 2, 3, 4 });
            var v2 = new RowVector(new double[] { 5, 6, 7, 8 });

            var expectedScalarProduct = 70;

            var scalarProduct = v1 * v2;

            Assert.AreEqual(expectedScalarProduct, scalarProduct);
        }

        [TestMethod]
        [ExpectedException(typeof(MultiplicationVectorDimensionException), "The vector have not the same length ( length of V1 : 4, length of V2 : 5 )")]
        public void ScalarProductExceptionTest()
        {
            var v1 = new RowVector(new double[] { 1, 2, 3, 4 });
            var v2 = new RowVector(new double[] { 5, 6, 7, 8, 9 });

            var scalarProduct = v1 * v2;
        }

        [TestMethod]
        public void TransposeTest()
        {
            var rowVector = new RowVector(new double[] { 1, 2, 3, 4 });

            var columnVector = rowVector.Transpose();

            var expectedColumnVector = new double[] { 1, 2, 3, 4 };

            Assert.IsInstanceOfType(columnVector, typeof(ColumnVector));

            bool isEqual = Helpers.AreEqualVector(expectedColumnVector, columnVector);
            Assert.IsTrue(isEqual);
        }
    }
}
