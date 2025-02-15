using System;

namespace LBautomation
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class DivideByZeroException : Exception
    {
        public DivideByZeroException(string message) : base(message) { }
    }


    public class Program
    {
        private static double ReadDouble(string message)
        {
            Console.Write(message);
            if (!double.TryParse(Console.ReadLine(), out double result))
            {
                throw new InvalidInputException("Некорректный ввод числа.");
            }
            else return result;
        }

        private static int ReadInteger(string message)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                throw new InvalidInputException("Некорректный ввод числа.");
            }
            else return result;
        }

        private static void WriteList(List<double> list)
        {
            int i = 1;
            foreach (double item in list)
            {
                Console.WriteLine($"Ответ для числа {i}: {item.ToString()}"); i++;
            }
        }

        public static int CheckNumberItem(int NumberItem)
        {            
            if (NumberItem <= 0 || NumberItem > 10)
            {
                throw new InvalidInputException("Некорректный ввод числа. Такого пункта с операцией нет.");
            } 
            else return NumberItem;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Деление");
            Console.WriteLine("4. Умножение");
            Console.WriteLine("5. Возведение в степень");
            Console.WriteLine("6. Извлечение корня");
            Console.WriteLine("7. Процент от числа");
            Console.WriteLine("8. Логарифм");
            Console.WriteLine("9. Синус (радианы)");
            Console.WriteLine("10. Котангенс (радианы)");
            Console.WriteLine("*Для возведения в степень, первое число - основание, второе - показатель степени.\n" +
                "*Для процента от числа, первое число - сколько составляет %, второе - от какого числа %.\n" +
                "*Для логорифма, первое число - подлогорифмическое выражение, второе - основание.");

            int NumberItem = ReadInteger("\nВыберите операцию (введите номер пункта): ");
            CheckNumberItem(NumberItem);

            int CountNumbers = ReadInteger("Введите количество чисел с которыми хотите провести операции: ");
            if (CountNumbers > 2 && (NumberItem == 5 || NumberItem == 7 || NumberItem == 8)) { Console.WriteLine($"Вычисление невозможно с больше двух чисел."); return; }
            List<double> ListNumbers = new List<double>(CountNumbers);
            for (int i = 0; i < CountNumbers; i++)
            {
                double Numbers = ReadDouble("Введите число: ");
                ListNumbers.Add(Numbers);
            }

            switch (NumberItem)
            {
                case 1: Console.WriteLine($"Ответ: {Addition(ListNumbers)}"); break;
                case 2: Console.WriteLine($"Ответ: {Subtraction(ListNumbers)}"); break;
                case 3: Console.WriteLine($"Ответ: {Division(ListNumbers)}"); break;
                case 4: Console.WriteLine($"Ответ: {Multiplication(ListNumbers)}"); break;
                case 5: Console.WriteLine($"Ответ: {Exponentiation(ListNumbers)}"); break;
                case 6: WriteList(RootExtraction(ListNumbers)); break;
                case 7: Console.WriteLine($"Ответ: {PercentageNumber(ListNumbers)}"); break;
                case 8: Console.WriteLine($"Ответ: {Logarithm(ListNumbers)}"); break;
                case 9: WriteList(Sin(ListNumbers)); break;
                case 10: WriteList(Ctg(ListNumbers)); break;
            }
        }

        public static double? Addition(List<double> list)
        {
            try
            {
                double result = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    result += list[i];
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}"); return null;
            }            
        }

        public static double? Subtraction(List<double> list)
        {
            try
            {
                double result = list[0];
                for (int i = 0; i < list.Count; i++)
                {
                    int index = i + 1;
                    if (list.Select((value, ind) => ind).Any(ind => ind >= index))
                    {
                        result -= list[index];
                    }
                    else break;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}"); return null;
            }            
        }

        public static double Division(List<double> list)
        {
            double result = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                int index = i + 1;

                if (list[i] == 0 && list[0] != 0)
                {
                    throw new DivideByZeroException("Деление на ноль невозможно.");
                }

                if (list.Select((value, ind) => ind).Any(ind => ind >= index))
                {
                    result /= list[index];
                }
                else break;
            }
            return result;
        }

        public static double? Multiplication(List<double> list)
        {
            try
            {
                double result = list[0];
                for (int i = 0; i < list.Count; i++)
                {
                    int index = i + 1;
                    if (list.Select((value, ind) => ind).Any(ind => ind >= index))
                    {
                        result *= list[index];
                    }
                    else break;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}"); return null;
            }
        }

        public static double Exponentiation(List<double> list)
        {
            double result = 0;
            if (list[0] <= 0)
            {
                throw new InvalidInputException("Основание должно быть больше нуля.");
            }
            else result = Math.Pow(list[0], list[1]);

            return result;
        }

        public static List<double> RootExtraction(List<double> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    throw new InvalidInputException("Нельзя извлечь корень из отрицательного числа.");
                }
                else list[i] = Math.Sqrt(list[i]);
            }

            return list;
        }

        public static double? PercentageNumber(List<double> list)
        {
            try
            {
                double result = 0;
                result = list[0]/100 * list[1];

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}"); return null;
            }
        }

        public static double Logarithm(List<double> list)
        {
            double result = 0;
            if (list[0] <= 0 || list[1] <= 0 || list[1] == 1)
            {
                throw new InvalidInputException("Нельзя вычислить логорифм.");
            }
            else result = Math.Log(list[0], list[1]);

            return result;
        }

        public static List<double>? Sin(List<double> list)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = Math.Sin(list[i]);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}"); return null;
            }
        }

        public static List<double>? Ctg(List<double> list)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = Math.Cos(list[i]) / Math.Sin(list[i]);
                }

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка вычисления: {ex.Message}"); return null;
            }
        }
    }
}