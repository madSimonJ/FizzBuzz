using System;
using System.Linq;

namespace FizzBuzz
{
    public static class SequenceGenerator
    {
        private static bool IsMultipleOfThree(int x) =>
            x % 3 == 0;

        private static bool IsMultipleOfFive(int x) =>
            x % 5 == 0;

        public static string ConvertNumberToString(int num)
        {
            if (IsMultipleOfThree(num) && IsMultipleOfFive(num))
                return "fizzbuzz";

            if(IsMultipleOfThree(num))
                return "fizz";

            if (IsMultipleOfFive(num))
                return "buzz";

            return num.ToString();
        }


        public static string GenerateFizzBuzz(int start, int end)
        {
            if (start > end)
                return $"Invalid sequence: The start ({start}) is higher than the end ({end}).  Please make the start number of the sequence higher than the end number (e.g. ({end}, {start}) )";

            return string.Join(" ",
                Enumerable.Range(start, end - start + 1)
                .Select(ConvertNumberToString)
            );
        }
    }
}

