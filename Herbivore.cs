public class Herbivore : Creature
{
    public Herbivore(int energy, int sightRange = 1) : base(energy, sightRange) { }

    public override void Move(Cell newCell)
    {
        if (CurrentCell != null)
        {
            CurrentCell.RemoveCreature(this);
        }

        newCell.AddCreature(this);
        CurrentCell = newCell;
    }

    public override void Eat(Plant plant)
    {
        if (plant != null)
        {
            Energy += plant.EnergyValue;
            CurrentCell.Plant = null;
        }
    }

    public void Act(World world)
    {
        var newCell = CurrentCell.GetRandomNeighbor(world);
        Move(newCell);

        if (CurrentCell.Plant != null)
        {
            Eat(CurrentCell.Plant);
        }
    }
}
