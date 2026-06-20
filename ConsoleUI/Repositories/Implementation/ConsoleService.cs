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
        private readonly IConfiguration _config;
        private readonly IDivisionService _divisionService;

        public ConsoleService(IDivisionService divisionService, ILogger<ConsoleService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
            _divisionService = divisionService;
        }

        public async Task Run()
        {
            do
            {
                Console.WriteLine("=== C# Basics Menu ===");
                Console.WriteLine("1. Division.");
                Console.WriteLine("Press Escape key to exit.");

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);
                char choice = char.ToLower(keyInfo.KeyChar);

                if (choice == 'x')
                {
                    Console.WriteLine("\nGoodbye!");
                    break;
                }


                switch (choice)
                {
                    case '1':
                        _log.LogInformation("Running Division...");

                        RunDivisionDemo();

                        _log.LogInformation("Done running Division!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        _log.LogError("\nInvalid option. Please try again.");
                        Console.WriteLine("\nInvalid option. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------");


            } while (true);
        }

        private void RunDivisionDemo()
        {
            Console.WriteLine("\n--- Division ---");
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

            Console.WriteLine("\n--- Running Division Methods ---");
            _divisionService.DivideWithExceptionAndCastDouble();
            _divisionService.DivideAndCastDouble();
            _divisionService.DivideAndCastInt();
            _divisionService.DivideAndCastFloat();
            _divisionService.DivideAndCastDecimal();
        }
    }
}
