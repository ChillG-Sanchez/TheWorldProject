using System;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        World world = new World(10, 10);

        while (true)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true);
                break;
            }

            Console.Clear();
            world.Update();
            world.Display();
            Thread.Sleep(1000);
        }
    }
}