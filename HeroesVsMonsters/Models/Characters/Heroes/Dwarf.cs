namespace HeroesVsMonsters.Models.Characters.Heroes;

public class Dwarf : Hero
{
    public override int Stamina => base.Stamina + 2;

    public Dwarf(string name) : base(name)
    {
    }
}