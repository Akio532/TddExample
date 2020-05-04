using System;
using task2_Csharp_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SystemLinearEquationProject
{
    [TestClass]
    public class UnitTest1
    {
            [TestMethod]
        public void Constructor()
        {
            int m = 2;
            SystemLinearEquation sle = new SystemLinearEquation(m);
            Assert.AreEqual("0=0\n0=0\n", sle.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorWithNegativeArgument()
        {
            int m = -2;
            Assert.Equals(typeof(ArgumentException), new SystemLinearEquation(m));
        }
        [TestMethod]
        public void Get()
        {
            SystemLinearEquation sle = new SystemLinearEquation(1);
            Assert.AreEqual("0=0", sle[0].ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetWithIncorrectArgument()
        {
            SystemLinearEquation sle = new SystemLinearEquation(1);
            Assert.Equals(typeof(ArgumentException), sle[-4].ToString());
        }
        [TestMethod]
        public void SetAndGet()
        {
            SystemLinearEquation sle = new SystemLinearEquation(2);
            sle[0] = new LinearEquationClass(new double[] { 1, 2, 3 });
            Assert.AreEqual("3x2+2x1+1=0", sle[0].ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetWithIncorrectArgument()
        {
            SystemLinearEquation sle = new SystemLinearEquation(2);
            Assert.Equals(typeof(ArgumentException), sle[3] = new LinearEquationClass(new double[4] { 1, 2, 3, 6 }));
        }
        [TestMethod]
        public void Triangular()
        {
            SystemLinearEquation sle = new SystemLinearEquation(3);
            sle[0] = new LinearEquationClass(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquationClass(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquationClass(new double[] { 3, 2, 1, -2 });
            sle.ToTriangular();
            Assert.AreEqual("2x3+1x2-1x1-8=0\n0,5x2+0,5x1-1=0\n-1x1-1=0\n", sle.ToString());
        }
        [TestMethod]
        public void Solve()
        {
            SystemLinearEquation sle = new SystemLinearEquation(3);
            sle[0] = new LinearEquationClass(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquationClass(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquationClass(new double[] { 3, 2, 1, -2 });
            Assert.IsTrue(new double[] { -1, 3, 2 }.SequenceEqual(sle.Solve()));
        }
        [TestMethod]
        public void SolveWithSameEquations()
        {
            SystemLinearEquation sle = new SystemLinearEquation(4);
            sle[0] = new LinearEquationClass(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquationClass(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquationClass(new double[] { 11, 2, -1, -3 });
            sle[3] = new LinearEquationClass(new double[] { 3, 2, 1, -2 });
            Assert.IsTrue(new double[] { -1, 3, 2 }.SequenceEqual(sle.Solve()));
        }
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void SolveWithContradictoryEquations()
        {
            SystemLinearEquation sle = new SystemLinearEquation(4);
            sle[0] = new LinearEquationClass(new double[] { -8, -1, 1, 2 });
            sle[1] = new LinearEquationClass(new double[] { 11, 2, -1, -3 });
            sle[2] = new LinearEquationClass(new double[] { 3, 2, 1, -2 });
            sle[3] = new LinearEquationClass(new double[] { 4, 2, 2, -2 });
            Assert.Equals(typeof(ArithmeticException), sle.Solve());

        }
    }
}