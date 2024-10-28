public interface ICreature
{
    int Energy { get; set; }
    int SightRange { get; }
    Cell CurrentCell { get; set; }
    void Move(Cell newCell);
    void Eat(Plant plant);
}