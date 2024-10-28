public abstract class Creature : ICreature
{
    public int Energy { get; set; }
    public Cell CurrentCell { get; set; }
    public int SightRange { get; private set; }

    public Creature(int energy, int sightRange)
    {
        Energy = energy;
        SightRange = sightRange;
    }

    public abstract void Move(Cell newCell);
    public abstract void Eat(Plant plant);
}
