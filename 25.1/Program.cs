using System;
using System.Threading;

class Program
{
    static AutoResetEvent autoEvent1 = new AutoResetEvent(true);
    static AutoResetEvent autoEvent2 = new AutoResetEvent(false);

    static void Main()
    {
        Thread t1 = new Thread(PrintEvenNumbers);
        Thread t2 = new Thread(PrintOddNumbers);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }

    static void PrintEvenNumbers()
    {
        for (int i = 2; i <= 20; i += 2)
        {
            autoEvent1.WaitOne();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(i);

            autoEvent2.Set();
        }
    }

    static void PrintOddNumbers()
    {
        for (int i = 1; i < 20; i += 2)
        {
            autoEvent2.WaitOne();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(i);

            autoEvent1.Set();
        }
    }
}
