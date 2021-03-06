﻿namespace Task_8_FibonacciNumbers.BL
{
    public class FibonacciNumbers
    {
        private int firstNumber;
        private int secondNumber;

        public FibonacciNumbers(int number)
        {
            int tempValue;
            firstNumber = 0;
            secondNumber = 1;
            while (secondNumber < number)
            {
                tempValue = checked(firstNumber + secondNumber);
                firstNumber = secondNumber;
                secondNumber = tempValue;
            }
            tempValue = secondNumber - firstNumber;
            secondNumber = firstNumber;
            firstNumber = tempValue;
        }
        public int GetNext()
        {
            int sum = checked(firstNumber + secondNumber);
            firstNumber = secondNumber;
            secondNumber = sum;
            return sum;
        }
    }
}
