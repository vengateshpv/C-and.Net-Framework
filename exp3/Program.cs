using System;
class Number
{
    public int Value;
    public Number(int value)
    {
        Value = value;
    }
    public static Number operator +(Number n1, Number n2)
    {
        return new Number(n1.Value + n2.Value);
    }
    public void Display()
    {
        Console.WriteLine("Result: " + Value);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Number num1 = new Number(10);
        Number num2 = new Number(20);
        Number sum = num1 + num2;
        sum.Display(); 
     }
}
