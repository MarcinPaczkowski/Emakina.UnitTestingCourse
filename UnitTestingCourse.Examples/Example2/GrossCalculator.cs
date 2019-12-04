namespace UnitTestingCourse.Examples.Example2
{
    public class GrossCalculator
    {
        private readonly ICalculator _calculator;
        private readonly CustomLogger _logger;

        public GrossCalculator(ICalculator calculator, CustomLogger logger)
        {
            _calculator = calculator;
            _logger = logger;
        }

        public decimal Calculate(decimal netValue, int tax)
        {
            if (tax < 0)
                throw new ValueLessThenZeroException();
            if (tax == 0) 
                return netValue;

            var id = _logger.LogToDatabase($"Net value: {netValue}, tax: {tax}");
            _logger.LogToConsole(id.ToString());

            var taxAsPercent = _calculator.Division(tax, 100);
            var taxValue = _calculator.Multiplication(netValue, taxAsPercent);
            var grossValue = _calculator.Add(netValue, taxValue);

            return grossValue;
        }
    }
}