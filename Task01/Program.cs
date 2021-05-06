using System;

/*
Источник: https://metanit.com/

Как известно, неотъемлемыми компонентами бутерброда являются хлеб и масло.
Допустим, у нас есть классы Bread, Butter, Sandwich.
Добавьте в один из классов оператор сложения, чтобы при объединении хлеба (Bread) и масла (Butter)
получался бутерброд (Sandwich), и, тем самым, компилировался и выполнялся без ошибок код в методе Main.
Обработайте ситуации, когда вес отрицательный (в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход может поступить строка (веса компонентов бутерброда, разделенные через пробел):
10 10
Программа должна вывести на экран:
20
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task01
{
    /// <summary>
    /// A bread.
    /// </summary>
    class Bread
    {
        // Bread weight.
        private int _weight;

        /// <summary>
        /// Bread weight.
        /// </summary>
        public int Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _weight = value;
            }
        }

        /// <summary>
        /// Make a sandwich.
        /// </summary>
        /// <param name="bread">A bread.</param>
        /// <param name="butter">A butter.</param>
        /// <returns>A sandwich.</returns>
        public static Sandwich operator +(Bread bread, Butter butter)
        {
            return new Sandwich { Weight = bread.Weight + butter.Weight };
        }
    }


    /// <summary>
    /// Butter.
    /// </summary>
    class Butter
    {
        // Butter weight.
        private int _weight;

        /// <summary>
        /// Butter weight.
        /// </summary>
        public int Weight
        {
            get => _weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _weight = value;
            }
        }
    }


    /// <summary>
    /// A sandwich.
    /// </summary>
    class Sandwich
    {
        /// <summary>
        /// A sandwich weight.
        /// </summary>
        public int Weight { get; set; }

    }

    class MainClass
    {
        public static void Main()
        {
            string[] strs = Console.ReadLine().Split();
            try
            {
                var bread = new Bread { Weight = int.Parse(strs[0]) };
                var butter = new Butter { Weight = int.Parse(strs[1]) };
                var sandwich = bread + butter;
                Console.WriteLine(sandwich.Weight);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}