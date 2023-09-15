public interface IShape
{
    double Area { get; }
}

public class Triangle : IShape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public double P { get; }

    public double Area => Math.Sqrt(P * (P - A) * (P - B) * (P - C));

    public bool IsRight => A * A + B * B == C * C || A * A + C * C == B * B || B * B + C * C == A * A;


    public Triangle(double a, double b, double c)
    {
        if (a <= 0 ||
           b <= 0 ||
           c <= 0 ||
           double.IsNaN(a) ||
           double.IsNaN(b) ||
           double.IsNaN(c) ||
           double.IsInfinity(a) ||
           double.IsInfinity(b) ||
           double.IsInfinity(c))
        {
            throw new ArgumentOutOfRangeException();
        }
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentOutOfRangeException();
        }
        this.A = a;
        this.B = b;
        this.C = c;
        this.P = (A + B + C) / 2;
    }
}

public class Circle : IShape
{
    public double Radius { get; }
    public double Area => double.Pi * Radius * Radius;

    public Circle(double radius)
    {
        if (radius <= 0 || double.IsInfinity(radius) || double.IsNaN(radius))
        {
            throw new ArgumentOutOfRangeException(nameof(radius));
        }
        this.Radius = radius;
    }
}

public class Square : IShape
{
    public double Side { get; }
    public double Area => Side * Side;

    public Square(double side)
    {
        if(side <= 0 || double.IsInfinity(side) || double.IsNaN(side))
        {
            throw new ArgumentOutOfRangeException(nameof(side));
        }
        this.Side = side;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("123");
    }
}