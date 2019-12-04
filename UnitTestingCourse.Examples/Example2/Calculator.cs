using System;

namespace UnitTestingCourse.Examples.Example2
{
    public class Calculator : ICalculator
    {
        public decimal Add(decimal a, decimal b)
        {
            var result = a + b;
            return result;
        }

        public decimal Subtraction(decimal a, decimal b)
        {
            var result =  a - b;
            return result;
        }

        public decimal Multiplication(decimal a, decimal b)
        {
            var result = a * b;
            return result;
        }

        public decimal Division(decimal a, decimal b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            var result =  a / b;
            return result;
        }
    }
}