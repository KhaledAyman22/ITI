using ConsoleApp;

namespace ConsoleAppTests
{
    [TestClass]
    public class FizzBuzzTests
    {
        private readonly string _divisibleBy3Result = "Fizz";
        private readonly string _divisibleBy5Result = "Buzz";
        private readonly string _divisibleBy3And5Result = "FizzBuzz";

        [TestMethod]
        public void Print_Number1_Print1()
        {
            var testingNumber = 1;
            var expected = "1";

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Print_Number4_Print4()
        {
            var testingNumber = 4;
            var expected = "4";

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Print_Number7_Print7()
        {
            var testingNumber = 7;
            var expected = "7";

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Print_Number3_Print3()
        {
            var testingNumber = 3;

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(_divisibleBy3Result, result);
        }

        [TestMethod]
        public void Print_Number12_Print12()
        {
            var testingNumber = 12;

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(_divisibleBy3Result, result);
        }

        [TestMethod]
        public void Print_Number5_Print5()
        {
            var testingNumber = 5;

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(_divisibleBy5Result, result);
        }

        [TestMethod]
        public void Print_Number50_Print50()
        {
            var testingNumber = 50;

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(_divisibleBy5Result, result);
        }

        [TestMethod]
        public void Print_Number15_Print15()
        {
            var testingNumber = 15;

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(_divisibleBy3And5Result, result);
        }

        [TestMethod]
        public void Print_Number30_Print30()
        {
            var testingNumber = 30;

            var result = FizzBuzz.Print(testingNumber);

            Assert.AreEqual(_divisibleBy3And5Result, result);
        }
    }
}