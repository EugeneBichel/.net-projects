using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorKata.Tests
{
    [TestClass]
    public class SimpleCalculatorTest
    {
        private SimpleCalculator _simpleCalculator;

        [TestInitialize]
        public void TestSetUp()
        {
            _simpleCalculator = new SimpleCalculator();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            
        }

        [TestMethod]
        public void Sum_ShouldReturnZero_WhenInputStringIsEmpty()
        {
            //arrange
            string delimitedOperands = string.Empty;
            int expectedSum = 0;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnAValue_WhenInputStringContainsTheValue()
        {
            //arrange
            string delimitedOperands = "2";
            int expectedSum = Convert.ToInt32(delimitedOperands);

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsTwoNumbersCommaDelimited()
        {
            //arrange
            const string delimitedOperands = "2,3";
            const int expectedSum = 5;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsTwoNumbersNewlineDelimited()
        {
            //arrange
            string delimitedOperands = $"1{Environment.NewLine}5";
            const int expectedSum = 6;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsThreeNumbersDelimitedByCommaOrNewLine()
        {
            //arrange
            string delimitedOperands = $"3,7{Environment.NewLine}9";
            const int expectedSum = 19;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sum_ShouldThrowAnException_WhenInputStringContainsNegativeNumber()
        {
            //arrange
            string delimitedOperands = "-2";

            //act
            _simpleCalculator.Sum(delimitedOperands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sum_ShouldThrowAnException_WhenInputStringContainsTwoNumbersCommaDelimited_And_OneOfNumbersIsNegative()
        {
            //arrange
            string delimitedOperands = "2,-3";

            //act
            _simpleCalculator.Sum(delimitedOperands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sum_ShouldThrowAnException_WhenInputStringContainsTwoNumbersNewlineDelimited_And_OneOfNumbersIsNegative()
        {
            //arrange
            string delimitedOperands = $"-2{Environment.NewLine}3";

            //act
            _simpleCalculator.Sum(delimitedOperands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Sum_ShouldThrowAnException_WhenInputStringContainsThreeNumbersDelimitedByCommaOrNewLine_And_OneOfNumbersIsNegative()
        {
            //arrange
            string delimitedOperands = $"-2,4{Environment.NewLine}3";

            //act
            _simpleCalculator.Sum(delimitedOperands);
        }

        [TestMethod]
        public void Sum_ShouldIgnore_WhenInputStringContainsNumberMoreThan1000()
        {
            //arrange
            string delimitedOperands = "1001";
            const int expectedSum = -1;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }
        
        [TestMethod]
        public void Sum_ShouldIgnore_WhenInputStringContainsTwoNumbersCommaDelimited_And_OneOfNumberMoreThan1000()
        {
            //arrange
            string delimitedOperands = "2,1001";
            const int expectedSum = -1;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldIgnore_WhenInputStringContainsTwoNumbersNewlineDelimited_And_OneOfNumberMoreThan1000()
        {
            //arrange
            string delimitedOperands = $"1001{Environment.NewLine}3";
            const int expectedSum = -1;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldIgnore_WhenInputStringContainsThreeNumbersDelimitedByCommaOrNewLine_And_OneOfNumberMoreThan1000()
        {
            //arrange
            string delimitedOperands = $"1001,4{Environment.NewLine}3";
            const int expectedSum = -1;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsTwoNumbersSharpDelimited_And_FirstCharsOfStringIsDefinitionOfSingleCharDelimiter()
        {
            //arrange
            string delimitedOperands = "//#2#3";
            const int expectedSum = 5;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsThreeNumbersDelimitedByCommaOrNewLine_And_FirstCharsOfStringIsDefinitionOfSingleCharDelimiter()
        {
            //arrange
            string delimitedOperands = $"//#1#4{Environment.NewLine}3";
            const int expectedSum = 8;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsTwoNumbersSharpDelimited_And_FirstCharsOfStringIsDefinitionOfMutiCharDelimiter()
        {
            //arrange
            string delimitedOperands = "//[###]2###3";
            const int expectedSum = 5;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsThreeNumbersDelimitedByCommaOrNewLine_And_FirstCharsOfStringIsDefinitionOfMutiCharDelimiter()
        {
            //arrange
            string delimitedOperands = $"//[###]1###4{Environment.NewLine}3";
            const int expectedSum = 8;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }

        [TestMethod]
        public void Sum_ShouldReturnSum_WhenInputStringContainsMoreThanOneDelimiters()
        {
            //arrange
            const string delimitedOperands = "//[###]//*//[::]2###3*1::4";
            const int expectedSum = 10;

            //act
            var actualSum = _simpleCalculator.Sum(delimitedOperands);

            //assert
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}
