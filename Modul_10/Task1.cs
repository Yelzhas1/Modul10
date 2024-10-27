using System;

namespace ConsoleCalculator
{    
    public interface ICalculator
    {
        int Calc(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Calc(int a, int b)
        {
            return a + b;
        }
    }

    class Task1
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
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
                    Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите целое число.");
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
                    Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите целое число.");
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
