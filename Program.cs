using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        World world = new World(10, 10);

        world.AddPlant(2, 3);
        world.AddPlant(5, 6);
        world.AddPlant(8, 8);

        Herbivore herbivore = new Herbivore(10);
        world.GetCell(1, 1).AddCreature(herbivore);

        int tick = 0;
        while (!Console.KeyAvailable)
        {
            Console.Clear();
            DisplayWorld(world);

            herbivore.Act(world);

            if (tick % 4 == 0)
            {
                world.SpreadPlants();
            }

            Thread.Sleep(500);
            tick++;
        }
    }

    static void DisplayWorld(World world)
    {
        for (int y = 0; y < world.Height; y++)
        {
            for (int x = 0; x < world.Width; x++)
            {
                var cell = world.GetCell(x, y);
                if (cell.Inhabitants.Count > 0)
                    Console.Write("C ");
                else if (cell.Plant != null)
                    Console.Write("P ");
                else
                    Console.Write(". ");
            }
            Console.WriteLine();
        }
    }
}
