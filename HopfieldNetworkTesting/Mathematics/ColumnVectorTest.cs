using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HopfieldNetwork.Mathematics;
using HopfieldNetwork.Exceptions;

namespace HopfieldNetworkTesting.Mathematics
{
    [TestClass]
    public class ColumnVectorTest
    {
        [TestMethod]
        public void InstantiateColumnVectorWithValueTest()
        {
            var vector = new ColumnVector(4);

            var expectedValues = new double[] { 0, 0, 0, 0 };

            bool isEqual = Helpers.AreEqualVector(expectedValues, vector);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void InstantiateColumnVectorWithArray()
        {
            var vector = new ColumnVector(new double[] { 1, 2, 3, 4 });

            var expectedValues = new double[] { 1, 2, 3, 4 };

            bool isEqual = Helpers.AreEqualVector(expectedValues, vector);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void InstantiateColumnVectorWithVector()
        {
            var vector = new ColumnVector(new Vector(new double[] { 1, 2, 3, 4 }));

            var expectedValues = new double[] { 1, 2, 3, 4 };

            bool isEqual = Helpers.AreEqualVector(expectedValues, vector);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void ScalarProductTest()
        {
            var v1 = new ColumnVector(new double[] { 1, 2, 3, 4 });
            var v2 = new ColumnVector(new double[] { 5, 6, 7, 8 });

            var expectedScalarProduct = 70;

            var scalarProduct = v1*v2;

            Assert.AreEqual(expectedScalarProduct, scalarProduct);
        }

        [TestMethod]
        [ExpectedException(typeof(MultiplicationVectorDimensionException), "The vector have not the same length ( length of V1 : 4, length of V2 : 5 )")]
        public void ScalarProductExceptionTest()
        {
            var v1 = new ColumnVector(new double[] { 1, 2, 3, 4 });
            var v2 = new ColumnVector(new double[] { 5, 6, 7, 8, 9 });

            var scalarProduct = v1*v2;
        }

        [TestMethod]
        public void TransposeTest()
        {
            var columnVector = new ColumnVector(new double[] { 1, 2, 3, 4 });

            var rowVector = columnVector.Transpose();

            var expectedRowVector = new double[] { 1, 2, 3, 4 };

            Assert.IsInstanceOfType(rowVector, typeof(RowVector));

            bool isEqual = Helpers.AreEqualVector(expectedRowVector, rowVector);
            Assert.IsTrue(isEqual);
        }
    }
}
