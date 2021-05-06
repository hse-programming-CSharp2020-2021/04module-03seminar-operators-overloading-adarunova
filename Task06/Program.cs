using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/



public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator)
    {
        var gcd = Gcd(numerator, denominator);

        if (denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }
        num = numerator / gcd;
        den = denominator / gcd;
    }

    public static Fraction Parse(string input)
    {
        var parts = input.Split('/');
        if (parts.Length == 2)
        {
            return new Fraction(int.Parse(parts[0]), int.Parse(parts[1]));
        }
        else
        {
            return new Fraction(int.Parse(parts[0]), 1);
        }
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int num = a.num * b.den + a.den * b.num;
        int den = a.den * b.den;
        return new Fraction(num, den);
    }

    public static Fraction operator -(Fraction a)
    {
        return new Fraction(a.num * (-1), a.den);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return a + (-b);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.num * b.num, a.den * b.den);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.num == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraction(a.num * b.den, a.den * b.num);
    }

    public override string ToString()
    {
        if (den == 1)
        {
            return num.ToString();
        }
        if (num == 0)
        {
            return "0";
        }
        return $"{num}/{den}";
    }

    public static int Gcd(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        return b == 0 ? a : Gcd(b, a % b);
    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            var a = Fraction.Parse(Console.ReadLine());
            var b = Fraction.Parse(Console.ReadLine());
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
    }
}
