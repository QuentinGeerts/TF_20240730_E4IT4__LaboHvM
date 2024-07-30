using HeroesVsMonsters.Interfaces;

namespace HeroesVsMonsters.Models.Characters.Monsters;

public class Dragon : Monster, IGold, ILeather
{
    public override int Stamina => base.Stamina + 1;
    public int Gold { get; set; }
    public int Leather { get; set; }

    public Dragon(string name) : base(name)
    {
        Gold = D6.Roll();
        Leather = D4.Roll();
    }

}