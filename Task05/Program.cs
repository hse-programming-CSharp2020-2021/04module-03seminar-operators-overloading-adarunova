using System;
using System.Globalization;

/*
Источник: https://metanit.com/

Класс Dollar представляет сумму в долларах, а Euro - сумму в евро.

Определите операторы преобразования от типа Dollar в Euro и наоборот.
Допустим, 1 евро стоит 1,14 долларов. При этом один оператор должен подразумевать явное,
и один - неявное преобразование. Обработайте ситуации с отрицательными аргументами
(в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество долларов и количество евро.
10
100
Программа должна вывести на экран количество евро и долларов, соответственно,
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
8,77
114,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task05
{
    class Dollar
    {
        private decimal _sum;

        public decimal Sum
        {
            get => _sum;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _sum = value;
            }
        }

        public static explicit operator Euro(Dollar dollar)
        {
            return new Euro { Sum = dollar.Sum / 1.14m };
        }

        public override string ToString()
        {
            return Sum.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"));
        }

    }


    class Euro
    {
        private decimal _sum;

        public decimal Sum
        {
            get => _sum;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _sum = value;
            }
        }

        public static implicit operator Dollar(Euro euro)
        {
            return new Dollar { Sum = euro.Sum * 1.14m };
        }

        public override string ToString()
        {
            return Sum.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"));
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

                var dollar = new Dollar { Sum = decimal.Parse(Console.ReadLine()) };
                var euro = new Euro { Sum = decimal.Parse(Console.ReadLine()) };

                Console.WriteLine((Euro)dollar);

                dollar = euro;
                Console.WriteLine(dollar);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
