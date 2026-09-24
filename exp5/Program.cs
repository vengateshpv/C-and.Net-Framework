using System;
using System.Threading;
class ThreadDemo
{
    public void DisplayNumbers()
    {
        for(int i=1;i<=5;i++)
        {
            Console.WriteLine("Numberthread:"+i);
            Thread.Sleep(500);
        }
    }
    public void DisplayAlphabets()
    {
        for (char ch = 'A'; ch <= 'E'; ch++)
        {
            Console.WriteLine("Alphabet thread:"+ch);
            Thread.Sleep(500);
        }
    }
}
class program
{
    static void Main(string[] args)
    {
        ThreadDemo obj=new ThreadDemo();
        Thread t1=new Thread(obj.DisplayNumbers);
        Thread t2=new Thread(obj.DisplayAlphabets);
        Console.WriteLine("starting thread..\n");
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("\n both threads complted");
        Console.ReadKey();
    }
}
