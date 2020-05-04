using System;
using task2_Csharp_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace LinearEquationProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTestLinearEquation
        {
            [TestMethod]
            public void StringConstructor()
            {
                string s = "1 1,5 2,6 -4 89 13,4";
                LinearEquationClass le = new LinearEquationClass(s);
                Assert.IsTrue(new double[] { 1, 1.5, 2.6, -4, 89, 13.4 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void StringConstructorWithEmptyString()
            {
                string s = "";
                LinearEquationClass le = new LinearEquationClass(s);
                Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void StringConstructorWithOneElement()
            {
                string s = "2";
                LinearEquationClass le = new LinearEquationClass(s);
                Assert.IsTrue(new double[] { 2, 0 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void StringConstructorWithIncorrectString()
            {
                string s = "1 g 2.25 -5.7 helloworld 3 k";
                Assert.Equals(typeof(ArgumentException), new LinearEquationClass(s));
            }
            [TestMethod]
            public void ListConstructorWithArray()
            {
                double[] arr = new double[4] { 0, -5.6, 4, 7 };
                LinearEquationClass le = new LinearEquationClass(arr);
                Assert.IsTrue(arr.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void ListConstructorWithList()
            {
                List<double> l = new List<double>() { 5, 7, 2.4, -78, 3 };
                LinearEquationClass le = new LinearEquationClass(l);
                Assert.IsTrue(l.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void ListConstructorWithEmptyCollection()
            {
                double[] arr = new double[] { };
                LinearEquationClass le = new LinearEquationClass(arr);
                Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void ListConstructorWithOneElement()
            {
                double[] arr = new double[] { 5 };
                LinearEquationClass le = new LinearEquationClass(arr);
                Assert.IsTrue(new double[] { 5, 0 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void LinearEquationConstructor()
            {
                double[] arr = new double[4] { 0, -5.6, 4, 7 };
                LinearEquationClass le1 = new LinearEquationClass(arr);
                LinearEquationClass le2 = new LinearEquationClass(le1);
                Assert.IsTrue(((double[])le1).SequenceEqual((double[])le2));
            }
            [TestMethod]
            public void IntConstructor()
            {
                int n = 3;
                LinearEquationClass le = new LinearEquationClass(n);
                Assert.IsTrue(new double[] { 0, 0, 0 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void IntConstructorWithOne()
            {
                int n = 1;
                LinearEquationClass le = new LinearEquationClass(n);
                Assert.IsTrue(new double[] { 0, 0 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void IntConstructorWithNegativeArgument()
            {
                int n = -1;
                Assert.Equals(typeof(ArgumentException), new LinearEquationClass(n));
            }
            [TestMethod]
            public void FillByDuplicates()
            {
                int n = 4;
                LinearEquationClass le = new LinearEquationClass(n);
                le.FillByDuplicates(7.3);
                Assert.IsTrue(new double[] { 7.3, 7.3, 7.3, 7.3 }.SequenceEqual((double[])le));
            }
            [TestMethod]
            public void FillByRandomWithEqualSeeds()
            {
                int n = 3;
                LinearEquationClass le1 = new LinearEquationClass(n);
                LinearEquationClass le2 = new LinearEquationClass(n);
                le1.FillByRandom(-5, 10, 100);
                le2.FillByRandom(-5, 10, 100);
                Assert.IsTrue(((double[])le1).SequenceEqual((double[])le2));
            }
            [TestMethod]
            public void Degree()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 1, 2, 3 });
                Assert.AreEqual(2, le.Degree);
            }
            [TestMethod]
            public void AdditionWithSameCountOfCoefficients()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[3] { 1, 2, 3 });
                LinearEquationClass le2 = new LinearEquationClass(new double[3] { 4, 5, 6 });
                Assert.IsTrue((new double[3] { 5, 7, 9 }).SequenceEqual((double[])(le1 + le2)));
            }
            [TestMethod]
            public void AdditionWithDifferentCountOfCoefficients()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[4] { 1, -5, 3, 7 });
                LinearEquationClass le2 = new LinearEquationClass(new double[3] { 4, 5, 6 });
                Assert.IsTrue((new double[4] { 5, 0, 9, 7 }).SequenceEqual((double[])(le1 + le2)));
            }
            [TestMethod]
            public void SubstractionWithSameCountOfCoefficients()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[3] { 5, 2, 0 });
                LinearEquationClass le2 = new LinearEquationClass(new double[3] { 1, 5, 1 });
                Assert.IsTrue((new double[3] { 4, -3, -1 }).SequenceEqual((double[])(le1 - le2)));
            }
            [TestMethod]
            public void SubstractionWithDifferentCountOfCoefficients()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[3] { 4, 5, 3 });
                LinearEquationClass le2 = new LinearEquationClass(new double[4] { 1, 5, 6, 8 });
                Assert.IsTrue((new double[4] { 3, 0, -3, -8 }).SequenceEqual((double[])(le1 - le2)));
            }
            [TestMethod]
            public void LeftMultiplication()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 4, -5, 3 });
                double k = 2;
                Assert.IsTrue((new double[3] { 8, -10, 6 }).SequenceEqual((double[])(k * le)));
            }
            [TestMethod]
            public void RightMultiplication()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { -4, 0, 7 });
                double k = 3;
                Assert.IsTrue((new double[3] { -12, 0, 21 }).SequenceEqual((double[])(le * k)));
            }
            [TestMethod]
            public void EqualityWithSameCountOfCoefficients()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[3] { 1, 2, 3 });
                LinearEquationClass le2 = new LinearEquationClass(new double[3] { 1, 2, 3 });
                Assert.IsTrue(le1 == le2);
            }
            [TestMethod]
            public void EqualityWithDifferentCountOfCoefficients()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[3] { 1, 2, 3 });
                LinearEquationClass le2 = new LinearEquationClass(new double[5] { 1, 2, 3, 0, 0 });
                Assert.IsTrue(le1 == le2);
            }
            [TestMethod]
            public void Inequality()
            {
                LinearEquationClass le1 = new LinearEquationClass(new double[3] { 1, 2, 3 });
                LinearEquationClass le2 = new LinearEquationClass(new double[3] { 1, 6, 3 });
                Assert.IsTrue(le1 != le2);
            }
            [TestMethod]
            public void TrueLinearEquation()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 1, 2, 1 });
                Assert.IsTrue(le ? true : false);
            }
            [TestMethod]
            public void FalseLinearEquation()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 2, 0, 0 });
                Assert.IsFalse(le ? true : false);
            }
            [TestMethod]
            public void Coefficient()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 2, 3, 1 });
                Assert.AreEqual(3, le[1]);
            }
            [TestMethod]
            public void ToString()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 2, 1, 4 });
                Assert.AreEqual("4x2+1x1+2=0", le.ToString());
            }
            [TestMethod]
            public void ToStringWithMinus()
            {
                LinearEquationClass le = new LinearEquationClass(new double[3] { 2, -1, 4 });
                Assert.AreEqual("4x2-1x1+2=0", le.ToString());
            }
        }
    }
}
