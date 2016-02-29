using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionOperations;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputException1()
        {
            //arrange

            Fraction test = new Fraction("11a/11");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputException2()
        {
            //arrange

            Fraction test = new Fraction("11/1a1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputException3()
        {
            //arrange

            Fraction test = new Fraction("11/0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputException4()
        {
            //arrange

            Fraction test = new Fraction("11/11/1");
        }


        [TestMethod]
       
        public void InputCorrect1()
        {
            //arrange

            Fraction test = new Fraction("11");

            //assert
            Assert.AreEqual(11, test.Numerator);
            Assert.AreEqual(1, test.Denominator);
        }

        [TestMethod]

        public void InputCorrect2()
        {
            //arrange

            Fraction test = new Fraction("-11/-12");

            //assert
            Assert.AreEqual(11, test.Numerator);
            Assert.AreEqual(12, test.Denominator);
        }

        [TestMethod]

        public void InputCorrect3()
        {
            //arrange

            Fraction test = new Fraction("11/-12");

            //assert
            Assert.AreEqual(-11, test.Numerator);
            Assert.AreEqual(12, test.Denominator);
        }

        [TestMethod]

        public void InputCorrect4()
        {
            //arrange

            Fraction test = new Fraction("-11/12");

            //assert
            Assert.AreEqual(-11, test.Numerator);
            Assert.AreEqual(12, test.Denominator);
        }

        [TestMethod]

        public void InputCorrect5()
        {
            //arrange

            Fraction test = new Fraction("0/11");

            //assert
            Assert.AreEqual(0, test.Numerator);
            Assert.AreEqual(1, test.Denominator);
        }


        [TestMethod]

        public void InputCorrect6()
        {
            //arrange

            Fraction test = new Fraction("6/12");

            //assert
            Assert.AreEqual(1, test.Numerator);
            Assert.AreEqual(2, test.Denominator);
        }

        [TestMethod]

        public void InputCorrect7()
        {
            //arrange

            Fraction test = new Fraction(6,12);

            //assert
            Assert.AreEqual(1, test.Numerator);
            Assert.AreEqual(2, test.Denominator);
        }

        [TestMethod]

        public void CalculationValid1()
        {
            //arrange

            Fraction test = new Fraction("1/3");
            Fraction test2 = new Fraction("1/2");

            //act

            var result = FractionCalculator.Add(test,test2);
           
            
            //assert
            Assert.AreEqual(5, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }


        [TestMethod]

        public void CalculationValid2()
        {
            //arrange

            Fraction test = new Fraction("1/3");
            Fraction test2 = new Fraction("1/2");

            //act

            var result = FractionCalculator.Sub(test, test2);


            //assert
            Assert.AreEqual(-1, result.Numerator);
            Assert.AreEqual(6, result.Denominator);
        }


        [TestMethod]

        public void CalculationValid3()
        {
            //arrange

            Fraction test = new Fraction("2/3");
            Fraction test2 = new Fraction("3/2");

            //act

            var result = FractionCalculator.Mul(test, test2);


            //assert
            Assert.AreEqual(1, result.Numerator);
            Assert.AreEqual(1, result.Denominator);
        }


        [TestMethod]

        public void CalculationValid4()
        {
            //arrange

            Fraction test = new Fraction("-1/3");
            Fraction test2 = new Fraction("-1/2");

            //act

            var result = FractionCalculator.Div(test, test2);


            //assert
            Assert.AreEqual(2, result.Numerator);
            Assert.AreEqual(3, result.Denominator);
        }


        [TestMethod]

        [ExpectedException(typeof(DivideByZeroException))]

        public void CalculationInValid1()
        {
            //arrange

            Fraction test = new Fraction("1/3");
            Fraction test2 = new Fraction("0");

            //act

            var result = FractionCalculator.Div(test, test2);


            //assert
            
        }
    }
}
