using FizzBuzz;
using FluentAssertions;
using Xunit;

namespace SequenceGenerator_Tests
{
    namespace Given_a_range_of_numbers_that_contains_a_multiple_of_3_but_not_of_5
    {
        public class When_generating_a_sequence
        {
            [Theory]
            [InlineData(1, 3, "1 2 fizz")]
            [InlineData(6, 9, "fizz 7 8 fizz")]
            [InlineData(11, 14, "11 fizz 13 14")]
            [InlineData(16, 19, "16 17 fizz 19")]
            public void Then_the_multiple_of_3_is_replaced_with_the_word_fizz(int start, int end, string result) =>
                SequenceGenerator.GenerateFizzBuzz(start, end).Should().Be(result);
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
                SequenceGenerator.GenerateFizzBuzz(start, end).Should().Be(result);
        }
    }

    namespace Given_a_range_of_numbers_that_contains_multiples_of_both_5_and_3
    {
        public class When_generating_a_sequence
        {
            [Fact]
            public void then_any_multiple_of_both_5_and_3_should_be_replaced_with_the_word_fizzbuzz() =>
                SequenceGenerator.GenerateFizzBuzz(1, 30).Should().Be("1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz fizz 22 23 fizz buzz 26 fizz 28 29 fizzbuzz");
        }
    }

    namespace Given_a_range_of_numbers_that_starts_with_zero
    {
        public class When_generating_a_sequence
        {
            [Fact]
            public void then_the_sequence_should_start_with_fizzbuzz() =>
                SequenceGenerator.GenerateFizzBuzz(0, 30).Should().StartWith("fizzbuzz 1", because: "zero is divisible by everything");
        }
    }

    namespace Given_a_range_of_numbers_that_have_an_end_value_lower_than_its_start_value
    {
        public class When_generating_a_sequence
        {
            [Fact]
            public void then_an_error_message_should_be_displayed_instead_of_a_sequence() =>
                SequenceGenerator.GenerateFizzBuzz(30, 1).Should().Be("Invalid sequence: The start (30) is higher than the end (1).  Please make the start number of the sequence higher than the end number (e.g. (1, 30) )");
        }
    }
}
