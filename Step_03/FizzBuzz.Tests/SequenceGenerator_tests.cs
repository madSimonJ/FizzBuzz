using FizzBuzz;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace SequenceGenerator_Tests
{
    namespace Given_a_range_of_numbers_that_contains_a_3_digit_but_no_others_that_are_multiples_of_3_or_5
    {
        public class When_generating_a_sequence
        {
            [Theory]
            [InlineData(1, 3, "1 2 lucky")]
            [InlineData(13, 14, "lucky 14")]
            [InlineData(29, 34, "29 lucky lucky lucky lucky lucky")]
            public void Then_numbers_with_a_3_digit_should_be_replaced_with_the_word_lucky(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Split(Environment.NewLine).First().Should().Be(result);

            [Theory]
            [InlineData(1, 3, "lucky: 1 integer: 2")]
            [InlineData(13, 14, "lucky: 1 integer: 1")]
            [InlineData(29, 34, "lucky: 5 integer: 1")]
            public void Then_the_sequence_should_be_followed_by_a_report_summarising_the_words_returned(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Split(Environment.NewLine).Last().Should().Be(result);
        }
    }

    namespace Given_a_range_of_numbers_that_contains_a_multiple_of_3_but_not_of_5
    {
        public class When_generating_a_sequence
        {
            [Theory]
            [InlineData(7, 9, "7 8 fizz")]
            [InlineData(11, 12, "11 fizz")]
            [InlineData(16, 19, "16 17 fizz 19")]
            public void Then_the_multiple_of_3_is_replaced_with_the_word_fizz(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Split(Environment.NewLine).First().Should().Be(result);

            [Theory]
            [InlineData(7, 9, "fizz: 1 integer: 2")]
            [InlineData(11, 12, "fizz: 1 integer: 1")]
            [InlineData(16, 19, "fizz: 1 integer: 3")]
            public void Then_the_sequence_should_be_followed_by_a_report_summarising_the_words_returned(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Split(Environment.NewLine).Last().Should().Be(result);
        }
    }

    namespace Given_a_range_of_numbers_that_contains_a_multiple_of_5_but_not_of_3
    {
        public class When_generating_a_sequence
        {
            [Theory]
            [InlineData(4, 5, "4 buzz")]
            [InlineData(10, 11, "buzz 11")]
            [InlineData(19, 20, "19 buzz")]
            public void Then_the_5_is_replaced_with_the_word_buzz(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Split(Environment.NewLine).First().Should().Be(result);

            [Theory]
            [InlineData(4, 5, "buzz: 1 integer: 1")]
            [InlineData(10, 11, "buzz: 1 integer: 1")]
            [InlineData(19, 20, "buzz: 1 integer: 1")]
            public void Then_the_sequence_should_be_followed_by_a_report_summarising_the_words_returned(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Split(Environment.NewLine).Last().Should().Be(result);
        }
    }

    namespace Given_a_range_of_numbers_that_contains_multiples_of_both_5_and_3_and_the_digit_3
    {
        public class When_generating_a_sequence
        {
            [Fact]
            public void then_any_multiple_of_both_5_and_3_should_be_replaced_with_the_word_fizzbuzz() =>
                SequenceGenerator.GenerateFizzBuzz(1, 30).Split(Environment.NewLine).First().Should().Be("1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz fizz 22 lucky fizz buzz 26 fizz 28 29 lucky");

            [Fact]
            public void Then_the_sequence_should_be_followed_by_a_report_summarising_the_words_returned() =>
                SequenceGenerator.GenerateFizzBuzz(1, 30).Split(Environment.NewLine).Last().Should().Be("fizz: 7 buzz: 4 fizzbuzz: 1 lucky: 4 integer: 14");
        }
    }

    namespace Given_a_range_of_numbers_that_starts_with_zero
    {
        public class When_generating_a_sequence
        {
            [Fact]
            public void then_the_sequence_should_start_with_fizzbuzz() =>
                SequenceGenerator.GenerateFizzBuzz(0, 30).Should().StartWith("fizzbuzz 1", because: "zero is divisible by everything, but does not contain a 3");
        }
    }

    namespace Given_a_range_of_numbers_that_have_an_end_value_lower_than_its_start_value
    {
        public class When_generating_a_sequence
        {
            [Fact]
            public void then_an_error_message_should_be_displayed_instead_of_a_sequence() =>
                SequenceGenerator.GenerateFizzBuzz(30, 1).Should().Be("Invalid sequence: The start (30) is higher than the end (1).  Please make the start number of the sequence higher than the end number (e.g. (1, 30) )");

            [Fact]
            public void then_there_should_not_be_a_report_appended() =>
                SequenceGenerator.GenerateFizzBuzz(30, 1).Split(Environment.NewLine).Count().Should().Be(1);
        }
    }
}
