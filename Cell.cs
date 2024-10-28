using System.Collections.Generic;
using System;

public class Cell
{
    public int X { get; }
    public int Y { get; }
    public Plant Plant { get; set; }
    public List<ICreature> Inhabitants { get; private set; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        Inhabitants = new List<ICreature>();
    }

    public void AddCreature(ICreature creature)
    {
        Inhabitants.Add(creature);
        creature.CurrentCell = this;
    }

    public void RemoveCreature(ICreature creature)
    {
        Inhabitants.Remove(creature);
    }

    public Cell GetRandomNeighbor(World world)
    {
        var neighbors = world.GetNeighbors(this);
        return neighbors[new Random().Next(neighbors.Count)];
    }

    public override string ToString()
    {
        if (Plant != null) return "P";
        if (Inhabitants.Count > 0) return "C";
        return ".";
    }
}
