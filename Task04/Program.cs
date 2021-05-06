using System;
using System.Globalization;

/*
Источник: https://metanit.com/

Класс Celcius представляет градусник по Цельсию, а Fahrenheit - градусник по Фаренгейту.
Определите операторы преобразования от типа Celcius и наоборот.
Преобразование температуры по шкале Фаренгейта (Tf) в температуру по шкале Цельсия (Tc): Tc = 5/9 * (Tf - 32).
Преобразование температуры по шкале Цельсия в температуру по шкале Фаренгейта: Tf = 9/5 * Tc + 32.

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество градусов в Фаренгейтах и количество градусов в Цельсиях.
50
50
Программа должна вывести на экран число градусов в Цельсиях и Фаренгейтах, соответственно
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
10,00
122,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task04
{
    class Celcius
    {
        public double Gradus { get; set; }

        public static explicit operator Celcius(Fahrenheit degree)
        {
            return new Celcius { Gradus = 5 * (degree.Gradus - 32) / 9 };
        }

        public override string ToString()
        {
            return Gradus.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"));
        }
    }

    class Fahrenheit
    {
        public double Gradus { get; set; }

        public static explicit operator Fahrenheit(Celcius degree)
        {
            return new Fahrenheit { Gradus = 9 * degree.Gradus / 5 + 32 };
        }

        public override string ToString()
        {
            return Gradus.ToString("F2", CultureInfo.GetCultureInfo("ru-RU"));
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

            var fahrenheit = new Fahrenheit { Gradus = double.Parse(Console.ReadLine()) };
            var celcius = new Celcius { Gradus = double.Parse(Console.ReadLine()) };

            Console.WriteLine((Celcius)fahrenheit);
            Console.WriteLine((Fahrenheit)celcius);
        }
    }
}
