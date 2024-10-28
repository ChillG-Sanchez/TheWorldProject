public class Plant
{
    public int EnergyValue { get; private set; }

    public Plant(int energyValue = 5)
    {
        EnergyValue = energyValue;
    }
}
