using System;
using System.Linq;
using System.Collections.Generic;

public class Herbivore : Creature
{
    public int Size { get; set; }

    public Herbivore(int energy, int sightRange, Cell currentCell, int size) 
        : base(energy, sightRange, currentCell)
    {
        Size = size;
    }


    public override void Eat(Creature other)
    {
        // nem eszik élőlényt, de creature és kell a creature class CS0534 hiba miatt.
        // Amugy ezt úgy hoztam össze, hogy a Plant az Plant és nem Creatureként hoztam létre.
        // De legalább működik, meg ez amúgy sem bug, hanem egy feature. - Cody
    }
    public override void Move(Cell newCell)
    {
        if (newCell != null && newCell != CurrentCell && !newCell.Inhabitants.OfType<Herbivore>().Any())
        {
            CurrentCell.RemoveCreature(this);
            newCell.AddCreature(this);
            CurrentCell = newCell;
        }
    }

    public Cell? FindBestCellToMove(World world)
    {
        List<Cell> neighbors = world.GetNeighbors(CurrentCell);
        Cell? bestCell = null;
        int bestScore = int.MinValue;

        List<Cell> visibleCells = new List<Cell>();
        for (int dx = -SightRange; dx <= SightRange; dx++)
        {
            for (int dy = -SightRange; dy <= SightRange; dy++)
            {
                if (dx == 0 && dy == 0) continue;
                Cell? cell = world.GetCell(CurrentCell.X + dx, CurrentCell.Y + dy);
                if (cell != null)
                {
                    visibleCells.Add(cell);
                }
            }
        }

        Cell? predatorCell = visibleCells
            .Where(cell => cell.Inhabitants.OfType<Carnivore>().Any())
            .OrderBy(cell => Math.Abs(cell.X - CurrentCell.X) + Math.Abs(cell.Y - CurrentCell.Y))
            .FirstOrDefault();

        foreach (var cell in neighbors)
        {
            if (cell.Inhabitants.OfType<Herbivore>().Any() || cell.Inhabitants.OfType<Carnivore>().Any())
            {
                continue;
            }

            int score = 0;
            if (cell.Plant != null)
            {
                score += 10;
            }

            if (predatorCell != null)
            {
                int distanceToPredator = Math.Abs(cell.X - predatorCell.X) + Math.Abs(cell.Y - predatorCell.Y);
                score += distanceToPredator;
            }

            if (score > bestScore)
            {
                bestScore = score;
                bestCell = cell;
            }
        }

        return bestCell ?? neighbors.FirstOrDefault(cell => !cell.Inhabitants.OfType<Herbivore>().Any() && !cell.Inhabitants.OfType<Carnivore>().Any());
    }

    public void EatPlant()
    {
        if (CurrentCell.Plant != null)
        {
            Energy += 10;
            CurrentCell.Plant = null;
        }
    }

    public void Reproduce(World world)
    {
        if (Energy >= 30)
        {
            List<Cell> neighbors = world.GetNeighbors(CurrentCell);
            foreach (var cell in neighbors)
            {
                if (!cell.Inhabitants.Any() && cell.Plant == null)
                {
                    Herbivore offspring = new Herbivore(10, SightRange, cell, Size);
                    world.AddCreature(offspring, cell.X, cell.Y);
                    Energy -= 10;
                    break;
                }
            }
        }
    }
}