﻿using System;
using System.Linq;

namespace FizzBuzz
{
    public static class SequenceGenerator
    {
        private static bool IsMultipleOfThree(int x) =>
            x % 3 == 0;

        private static bool IsMultipleOfFive(int x) =>
            x % 5 == 0;

        private static int CalculateNumberRangeSize(int start, int end) =>
            end - start + 1;

        private static bool ContainsDigitThree(int num) =>
            num.ToString().Any(x => x == '3');

        private static string ConvertNumberToString(int num) =>
            num switch
            {
                _ when ContainsDigitThree(num) => "lucky",
                _ when IsMultipleOfThree(num) && IsMultipleOfFive(num) => "fizzbuzz",
                _ when IsMultipleOfThree(num) => "fizz",
                _ when IsMultipleOfFive(num) => "buzz",
                _ => num.ToString()
            };

        public static string GenerateFizzBuzz(int start, int end)
        {
            if (start > end)
                return $"Invalid sequence: The start ({start}) is higher than the end ({end}).  Please make the start number of the sequence higher than the end number (e.g. ({end}, {start}) )";

            var numbersToConvert = Enumerable.Range(start, CalculateNumberRangeSize(start, end));
            var convertedNumbers = numbersToConvert.Select(ConvertNumberToString);
            var convertedNumbersJoinedWithASpace = string.Join(" ", convertedNumbers);
            return convertedNumbersJoinedWithASpace;
        }
    }
}

