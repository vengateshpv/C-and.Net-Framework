using System;
public delegate void Notify();
class Publisher
{
    public event Notify OnNotify;
    public void RaiseEvent()
    {
        Console.WriteLine("Event is raised.");
        OnNotify?.Invoke();
    }}
class Subscriber
{
    public void ShowMessage()
    {
        Console.WriteLine("Event received successfully.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Publisher pub = new Publisher();
        Subscriber sub = new Subscriber();
        pub.OnNotify += sub.ShowMessage;
        pub.RaiseEvent();
    }
}

