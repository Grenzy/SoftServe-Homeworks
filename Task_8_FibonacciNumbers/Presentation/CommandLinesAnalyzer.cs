﻿using System;

namespace Task_8_FibonacciNumbers.Presentation
{
    public class CommandLinesAnalyzer
    {
        public static void Parse(string[] args, out int lowerBound, out int upperBound)
        {
            int length = args.Length;

            if (length > 2)
            {
                throw new ArgumentOutOfRangeException("The number of arguments is more than allowed.");
            }
            if (length < 2)
            {
                throw new ArgumentOutOfRangeException("The number of arguments is less than the allowed");
            }

            try
            {
                lowerBound = int.Parse(args[0]);
            }
            catch (FormatException e)
            {
                throw new FormatException("Invalid first argument format", e);
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"First argument must be a number between -2147483648 and 2147483647", e);
            }
            try
            {
                upperBound = int.Parse(args[1]);
            }
            catch (FormatException e)
            {
                throw new FormatException("Invalid second argument format", e);
            }
            catch (OverflowException e)
            {
                throw new OverflowException($"Second argument must be a number between -2147483648 and 2147483647", e);
            }

            if (lowerBound > upperBound)
            {
                throw new ArgumentException("The upper bound must be greater than the lower");
            }
        }
    }
}
