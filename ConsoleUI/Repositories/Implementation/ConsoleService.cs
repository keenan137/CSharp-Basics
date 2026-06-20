using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCoreConsoleApp.Repositories.Interface;
using System;
using System.Threading.Tasks;

namespace NetCoreConsoleApp.Repositories.Implementation
{
    public class ConsoleService : IConsoleService
    {
        private readonly ILogger<ConsoleService> _log;
        private readonly IDivisionService _divisionService;
        private readonly IDoubleService _doubleService;

        public ConsoleService(IDivisionService divisionService, ILogger<ConsoleService> log, IDoubleService doubleService)
        {
            _log = log;
            _divisionService = divisionService;
            _doubleService = doubleService;
        }

        public async Task Run()
        {
            do
            {
                Console.WriteLine("=== C# Basics Menu ===");
                Console.WriteLine("1. Division.");
                Console.WriteLine("2. Double.");
                Console.Write("Select an option (or press X to exit): ");

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);
                char choice = char.ToLower(keyInfo.KeyChar);

                if (choice == 'x')
                {
                    Console.WriteLine("\nGoodbye!");
                    break;
                }

                Console.WriteLine("\n\n------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------"); 

                switch (choice)
                {
                    case '1':
                        _log.LogInformation("Running Division...");

                        RunDivisionDemo();

                        _log.LogInformation("Done running Division!");
                        break;
                    case '2':
                        _log.LogInformation("Running Double...\n");

                        _doubleService.AdditionError();

                        _log.LogInformation("Done running Double!\n");
                        break;
                    default:
                        _log.LogError("\nInvalid option. Please try again.");
                        break;
                }
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------");
            } while (true);
        }

        private void RunDivisionDemo()
        {
            Console.Write("Enter the first number (dividend): ");
            if (!double.TryParse(Console.ReadLine(), out double first))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.Write("Enter the second number (divisor): ");
            if (!double.TryParse(Console.ReadLine(), out double second))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            _log.LogInformation("--- Running Division Methods ---");
            _divisionService.Initialize(first, second);
            _divisionService.DivideWithExceptionAndCastDouble();
            _divisionService.DivideAndCastDouble();
            _divisionService.DivideAndCastInt();
            _divisionService.DivideAndCastFloat();
            _divisionService.DivideAndCastDecimal();
        }
    }
}
