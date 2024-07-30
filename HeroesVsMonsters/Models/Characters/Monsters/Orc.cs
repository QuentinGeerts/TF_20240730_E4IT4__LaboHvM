using HeroesVsMonsters.Interfaces;

namespace HeroesVsMonsters.Models.Characters.Monsters;

public class Orc : Monster, IGold
{
    public override int Strength => base.Strength + 1;
    public int Gold { get; set; }

    public Orc(string name) : base(name)
    {
        Gold = D6.Roll();
    }

}