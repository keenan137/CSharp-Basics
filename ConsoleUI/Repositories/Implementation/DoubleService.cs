using Microsoft.Extensions.Logging;
using NetCoreConsoleApp.Repositories.Interface;
using System;

namespace NetCoreConsoleApp.Repositories.Implementation
{
    internal class DoubleService : IDoubleService
    {
        private readonly ILogger<DivisionService> _logger;

        public DoubleService(ILogger<DivisionService> logger)
        {
            _logger = logger;
        }

        public void AdditionError()
        {
            Console.WriteLine("Small rounding errors accumulate during calcuations (e.g. with 0.1)");
            double sum = 0.1 + 0.2;
            Console.WriteLine($"0.1 + 0.2 = {sum:G17}");
        }
    }
}
