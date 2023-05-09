using ConsoleApp;
using System;
using TechTalk.SpecFlow;

namespace ConsoleAppTests
{
    [Binding]
    public class PrintFizzSteps
    {
        private int _userNumber;
        private string _result;

        [Given(@"User enters number (.*)")]
        public void GivenUserEntersNumber(int number)
        {
            _userNumber= number;
        }

        [When(@"Print function is called")]
        public void WhenPrintFunctionIsCalled()
        {
            _result = FizzBuzz.Print(_userNumber);
        }

        [Then(@"""([^""]*)"" should be printed")]
        public void ThenShouldBePrinted(string fizz)
        {
            StringAssert.Matches(_result, new System.Text.RegularExpressions.Regex(fizz));
        }
    }
}
