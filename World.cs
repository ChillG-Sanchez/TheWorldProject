using System.Collections.Generic;

public class World
{
    public int Width { get; }
    public int Height { get; }
    private Cell[,] Cells;

    public World(int width, int height)
    {
        Width = width;
        Height = height;
        Cells = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cells[x, y] = new Cell(x, y);
            }
        }
    }

    public Cell GetCell(int x, int y) => Cells[x, y];

    public List<Cell> GetNeighbors(Cell cell)
    {
        var neighbors = new List<Cell>();

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int newX = cell.X + dx;
                int newY = cell.Y + dy;

                if ((dx != 0 || dy != 0) &&
                    newX >= 0 && newX < Width &&
                    newY >= 0 && newY < Height)
                {
                    neighbors.Add(Cells[newX, newY]);
                }
            }
        }

        return neighbors;
    }

    public void AddPlant(int x, int y)
    {
        var cell = GetCell(x, y);
        if (cell.Plant == null)
        {
            cell.Plant = new Plant();
        }
    }

    public void SpreadPlants()
    {
        List<Cell> cellsWithPlants = new List<Cell>();

        foreach (var cell in Cells)
        {
            if (cell.Plant != null)
            {
                cellsWithPlants.Add(cell);
            }
        }

        foreach (var cell in cellsWithPlants)
        {
            var neighbor = cell.GetRandomNeighbor(this);
            if (neighbor.Plant == null)
            {
                neighbor.Plant = new Plant();
            }
        }
    }


}
