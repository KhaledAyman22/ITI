using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class StringCalculator
    {
        #region Version 1 Empty String
        //public static int Add(string numbers)
        //{
        //    return 0;
        //}
        #endregion

        #region Version 2 One Number String
        //public static int Add(string numbers)
        //{
        //    return numbers == ""? 0 : int.Parse(numbers);
        //}
        #endregion

        #region Version 3 Two Numbers String
        //public static int Add(string numbers)
        //{
        //    if (numbers == "") return 0;

        //    if(numbers.Length == 1) return int.Parse(numbers);

        //    var numbersArr = numbers.Split(',');

        //    return int.Parse(numbersArr[0]) + int.Parse(numbersArr[1]);
        //}
        #endregion


        #region Version 4 N Numbers String
        //public static int Add(string numbers)
        //{
        //    if (numbers == "") return 0;

        //    var numbersArr = numbers.Split(',');

        //    return numbersArr.Sum(n => int.Parse(n));
        //}
        #endregion

        #region Version 5 N Numbers With New Lines String
        //public static int Add(string numbers)
        //{
        //    if (numbers == "") return 0;

        //    var numbersArr = numbers.Split(',', '\n');

        //    return numbersArr.Sum(n => int.Parse(n));
        //}
        #endregion

        #region Version 6 N Numbers With New Lines And Negatives String
        public static int Add(string numbers)
        {
            if (numbers == "") return 0;

            var numbersArr = numbers.Split(',', '\n');

            var negatives = numbersArr.Where(n => n[0] == '-');
            var negativesStr = string.Join(",", negatives);

            if (negativesStr != "")
                throw new NegativeNumbersEncounteredException(
                    $"The numbers string had the following negative value/s: {negativesStr}");

            return numbersArr.Sum(n => int.Parse(n));
        }
        #endregion
    }
}
