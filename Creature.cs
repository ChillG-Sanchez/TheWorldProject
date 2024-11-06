public abstract class Creature
{
    public int Energy { get; set; }
    public int SightRange { get; set; }
    public Cell CurrentCell { get; set; }

    public Creature(int energy, int sightRange, Cell currentCell)
    {
        Energy = energy;
        SightRange = sightRange;
        CurrentCell = currentCell;
    }

    public abstract void Move(Cell newCell);
    public abstract void Eat(Creature other);

    public bool IsAlive()
    {
        return Energy > 0;
    }
}