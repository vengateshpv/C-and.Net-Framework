using System;

// Class to demonstrate operator overloading
class Distance
{
    public int Meter;

    // Constructor
    public Distance(int meter)
    {
        Meter = meter;
    }

    // Overloading - operator
    public static Distance operator -(Distance d1, Distance d2)
    {
        return new Distance(d1.Meter - d2.Meter);
    }

    // Method to display value
    public void Display()
    {
        Console.WriteLine("Distance: " + Meter + " meters");
    }
}

// Main class
class Program
{
    static void Main(string[] args)
    {
        Distance d1 = new Distance(100);
        Distance d2 = new Distance(40);

        // Using overloaded - operator
        Distance result = d1 - d2;

        result.Display();
    }
}