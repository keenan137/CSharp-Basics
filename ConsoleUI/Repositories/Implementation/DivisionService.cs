using Microsoft.Extensions.Logging;
using NetCoreConsoleApp.Repositories.Interface;
using System;

namespace NetCoreConsoleApp.Repositories.Implementation
{
    internal class DivisionService : IDivisionService
    {
        private double _first { get; init; }
        private double _second { get; init; }

        private readonly ILogger<DivisionService> _logger;

        public DivisionService(double first, double second)
        {
            _first = first;
            _second = second;
        }

        public DivisionService(ILogger<DivisionService> logger)
        {
            _logger = logger;
        }

        public void DivideWithExceptionAndCastDouble()
        {
            if (_second == 0)
            {
                _logger.LogError("Cannot divide by zero");
            }

            double result = _first / _second;
            Console.WriteLine($"{nameof(DivideWithExceptionAndCastDouble)} : {result}");
        }

        public void DivideAndCastDouble()
        {
            double result = _first / _second;
            if (result == double.PositiveInfinity)
            {
                _logger.LogError("PositiveInfinity => _first={0}, _second={1}", _first, _second);
            }
            else
            {
                Console.WriteLine($"{nameof(DivideAndCastDouble)} : {result}");
            }
        }

        public void DivideAndCastInt()
        {
            int result = (int)(_first / _second);
            Console.WriteLine($"{nameof(DivideAndCastInt)} : {result}");
        }

        public void DivideAndCastFloat()
        {
            try
            {
                float result = (float)(_first / _second);
                Console.WriteLine($"{nameof(DivideAndCastFloat)} : {result}");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Something went wrong: {0}", ex.Message);
            }
        }

        public void DivideAndCastDecimal()
        {
            try
            {
                decimal result = (decimal)(_first / _second);
                Console.WriteLine($"{nameof(DivideAndCastDecimal)} : {result}");
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"{nameof(DivideAndCastDecimal)} - Something went wrong: {ex.Message}");
            }
        }
    }
}
