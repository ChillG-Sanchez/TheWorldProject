using System.Collections.Generic;

public class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public List<Creature> Inhabitants { get; set; } = new List<Creature>();
    public Plant? Plant { get; set; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void AddCreature(Creature creature)
    {
        Inhabitants.Add(creature);
    }

    public void RemoveCreature(Creature creature)
    {
        Inhabitants.Remove(creature);
    }

    public void AddPlant(Plant plant)
    {
        Plant = plant;
    }
}