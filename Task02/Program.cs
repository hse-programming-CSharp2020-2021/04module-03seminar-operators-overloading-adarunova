using System;

/*
Источник: https://metanit.com/

Есть класс State, который представляет государство.
Добавьте в класс оператор сложения, который бы позволял объединять государства (складывается и площадь, и население).
А также операторы сравнения < и > для сравнения государств по плотности населения (число людей / площадь).
На вход программы поступает информация о двух странах. Необходимо вывести через пробел площадь и
население большей страны. Затем объединить эти две страны в одну и вывести через пробел её
площадь и население.
Обработайте ситуации, когда население и площадь отрицательны, а также случай, когда площадь равна 0
(в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки (первая строка - это площадь и население первой страны,
вторая строка - это площадь и население второй страны).
10 10
200 20
Программа должна вывести на экран:
200 20
210 30

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task02
{
    /// <summary>
    /// A state.
    /// </summary>
    class State
    {
        // A population.
        private decimal _population;

        // An area.
        private decimal _area;

        /// <summary>
        /// A population.
        /// </summary>
        public decimal Population
        {
            get => _population;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _population = value;
            }
        }

        /// <summary>
        /// An area.
        /// </summary>
        public decimal Area
        {
            get => _area;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                _area = value;
            }
        }

        /// <summary>
        /// Unite states.
        /// </summary>
        /// <param name="a">The first state.</param>
        /// <param name="b">The second state.</param>
        /// <returns>United states.</returns>
        public static State operator +(State a, State b)
        {
            return new State { Population = a.Population + b.Population, Area = a.Area + b.Area };
        }


        /// <summary>
        /// Compare two states.
        /// </summary>
        /// <param name="a">The first state.</param>
        /// <param name="b">The second state.</param>
        /// <returns>True, if the density of the first state is bigger; otherwise, false.</returns>
        public static bool operator >(State a, State b)
        {
            return a.Population / a.Area > b.Population / b.Area;
        }


        /// <summary>
        /// Compare two states.
        /// </summary>
        /// <param name="a">The first state.</param>
        /// <param name="b">The second state.</param>
        /// <returns>True, if the density of the second state is bigger; otherwise, false.</returns>
        public static bool operator <(State a, State b)
        {
            return a.Population / a.Area < b.Population / b.Area;
        }


        public override string ToString()
        {
            return $"{Area} {Population}";
        }
    }

    class MainClass
    {
        public static void Main()
        {
            string[] strs = Console.ReadLine().Split();
            try
            {
                Console.WriteLine(strs[0] + " " + strs[1]);
                var state1 = new State { Area = int.Parse(strs[0]), Population = int.Parse(strs[1]) };
                strs = Console.ReadLine().Split();
                Console.WriteLine(strs[0] + " " + strs[1]);
                var state2 = new State { Area = int.Parse(strs[0]), Population = int.Parse(strs[1]) };

                if (state1 > state2)
                {
                    Console.WriteLine(state1);
                }
                else
                {
                    Console.WriteLine(state2);
                }

                var state3 = state1 + state2;

                Console.WriteLine(state3);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}