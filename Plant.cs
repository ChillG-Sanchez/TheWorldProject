using System;
using System.Collections.Generic;

public class Plant
{
    public int GrowthLevel { get; private set; }
    public bool IsFullyGrown => GrowthLevel >= 5;

    public Plant()
    {
        GrowthLevel = 0;
    }

    public void Grow()
    {
        if (GrowthLevel < 5)
        {
            GrowthLevel++;
        }
    }

    public void Spread(World world, Cell currentCell)
    {
        if (IsFullyGrown)
        {
            List<Cell> neighbors = world.GetNeighbors(currentCell);
            foreach (var cell in neighbors)
            {
                if (cell.Plant == null && !cell.Inhabitants.Any())
                {
                    cell.Plant = new Plant();
                    break;
                }
            }
        }
    }

    public void GetEaten()
    {
        GrowthLevel = 0;
    }
}