using Microsoft.Extensions.Logging;
using NetCoreConsoleApp.Repositories.Interface;
using System;

namespace NetCoreConsoleApp.Repositories.Implementation
{
    internal class DivisionService : IDivisionService
    {
        private double _first;
        private double _second;

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

        public void Initialize(double first, double second)
        {
            _first = first;
            _second = second;
        }

        public void DivideWithExceptionAndCastDouble()
        {
            if (_second == 0)
            {
                _logger.LogError($"{nameof(DivideWithExceptionAndCastDouble)} : Cannot divide by zero.");
                Console.WriteLine("\n");
                return;
            }

            double result = _first / _second;
            Console.WriteLine($"{nameof(DivideWithExceptionAndCastDouble)} : {result}");
            Console.WriteLine("\n");
        }

        public void DivideAndCastDouble()
        {
            double result = _first / _second;
            if (result == double.PositiveInfinity)
            {
                _logger.LogError($"{nameof(DivideAndCastDouble)} : PositiveInfinity => _first= {_first}, _second={_second}");
            }
            else
            {
                Console.WriteLine($"{nameof(DivideAndCastDouble)} : {result}");
            }

            Console.WriteLine("\n");
        }

        public void DivideAndCastInt()
        {
            unchecked
            {
                Console.WriteLine("Unchecked:");
                int result = (int)(_first / _second);
                Console.WriteLine($"{nameof(DivideAndCastInt)} : {result}");
            }

            try
            {
                checked
                {
                    Console.WriteLine("\nChecked:");
                    int result = (int)(_first / _second);
                    Console.WriteLine($"{nameof(DivideAndCastInt)} : {result}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"{nameof(DivideAndCastInt)} : Something went wrong - {ex.GetType()} {ex.Message}");
            }


            Console.WriteLine("\n");
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
                _logger.LogCritical($"{nameof(DivideAndCastFloat)} : Something went wrong: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n");
            }
        }

        public void DivideAndCastDecimal()
        {
            try
            {
                var initialValue = (_first / _second);
                Console.WriteLine($"Initial Value = {initialValue}");
                decimal result = (decimal)initialValue;
                Console.WriteLine($"{nameof(DivideAndCastDecimal)} : {result}");
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"{nameof(DivideAndCastDecimal)} - Something went wrong: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n");
            }
        }
    }
}
