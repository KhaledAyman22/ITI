using Task;

namespace Test
{
    [TestClass]
    public class StringCalculatorTest
    {


        #region Version 1 Empty String
        [TestMethod]
        public void StringCalculator_EmptyString_Result_0()
        {
            var numbers = "";
            var expected = 0;


            var result = StringCalculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }
        #endregion

        #region Version 2 One Number String
        [TestMethod]
        public void StringCalculator_Numbers1_Result_1()
        {
            var numbers = "1";
            var expected = 1;


            var result = StringCalculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }
        #endregion

        #region Version 3 Two Numbers String
        [TestMethod]
        public void StringCalculator_Numbers1_2_Result_1()
        {
            var numbers = "1,2";
            var expected = 3;


            var result = StringCalculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }
        #endregion

        #region Version 4 N Numbers String
        [TestMethod]
        public void StringCalculator_Numbers1_2_3_4_5_6_7_8_9_10_Result_55()
        {
            var numbers = "1,2,3,4,5,6,7,8,9,10";
            var expected = 55;


            var result = StringCalculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }
        #endregion

        #region Version 5 N Numbers With New Lines String
        [TestMethod]
        public void StringCalculator_Numbers1_2_3_4_NL_5_6_7_NL_8_9_10_Result_55()
        {
            var numbers = "1,2,3,4\n5,6,7\n8,9,10";
            var expected = 55;


            var result = StringCalculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }
        #endregion

        #region Version 6 N Numbers With New Lines And Negatives String
        [TestMethod]
        public void StringCalculator_Numbers1_2_n3_4_NL_5_n6_n7_NL_8_9_10_Result_55()
        {
            var numbers = "1,2,-3,4\n5,6,-7\n8,9,10";

            Action action = () => StringCalculator.Add(numbers);

            Assert.ThrowsException<NegativeNumbersEncounteredException>(action);
        }
        #endregion
    }
}