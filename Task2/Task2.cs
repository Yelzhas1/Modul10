using System;

namespace ConsoleCalculator
{
    public interface ILogger
    {
        void Error(string message);
        void Event(string message);
    }

    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ошибка: {0}", message);
            Console.ResetColor();
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Событие: {0}", message);
            Console.ResetColor();
        }
    }

    interface ICalculator
    {
        int Calc(int a, int b);
    }

    class Calculator : ICalculator
    {
        ILogger Logger { get; }

        public Calculator(ILogger logger)
        {
            Logger = logger;
        }

        public int Calc(int a, int b)
        {
            int result = a + b;
            Logger.Event($"Выполнение сложения: {a} + {b} = {result}");
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            ICalculator calculator = new Calculator(logger);

            int number1 = 0, number2 = 0;
            bool ValidInput = true;

            while (ValidInput)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    number1 = int.Parse(Console.ReadLine());
                    ValidInput = false;
                }
                catch (FormatException)
                {
                    logger.Error("Введено некорректное значение. Пожалуйста, введите целое число.");
                }
                finally
                {
                    Console.WriteLine("Первое число введено");
                }
            }

            ValidInput = true;

            while (ValidInput)
            {
                try
                {
                    Console.Write("Введите второе число: ");
                    number2 = int.Parse(Console.ReadLine());
                    ValidInput = false;
                }
                catch (FormatException)
                {
                    logger.Error("Введено некорректное значение. Пожалуйста, введите целое число.");
                }
                finally
                {
                    Console.WriteLine("Второе число введено");
                }
            }

            int result = calculator.Calc(number1, number2);
            Console.WriteLine("Результат сложения: {0}", result);
        }
    }
}
