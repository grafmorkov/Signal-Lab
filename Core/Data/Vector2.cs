namespace SignalLab.Core.Data;
public class Vector2
{
    private double _x;
    private double _y;

    public double X
    {
        get => _x;
        set { _x = value; }
    }

    public double Y
    {
        get => _y;
        set { _y = value; }
    }

    public Vector2()
    {
        X = 0;
        Y = 0;
    }

    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Vector2(Vector2 v)
    {
        X = v.X;
        Y = v.Y;
    }

    public void Print()
    {
        Console.WriteLine($"({X}, {Y})");
    }
}