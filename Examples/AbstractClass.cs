using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Shape
{
    public abstract int GetArea();
}

abstract class Car : Shape
{
    public abstract string Name { get; }
}

class Square : Shape
{
    private int _side;

    public Square(int n) => _side = n;

    // GetArea method is required to avoid a compile-time error.
    public override int GetArea() => _side * _side;
}

class Volvo : Car
{
    private int _side;
    private string _name;
    public Volvo(int n, string name)
    { _side = n; _name = name; }

    public override string Name => _name;

    public override int GetArea() => _side * _side;

}

public class Person
{
    public int Id;
}

public class A
{
    protected A()
    {
        Console.WriteLine("A");
    }
}

public class B:A
{
    public B()
    {
        Console.WriteLine("B");
    }
}

public class C : B
{
    public C()
    {
        Console.WriteLine("C");
    }
}

