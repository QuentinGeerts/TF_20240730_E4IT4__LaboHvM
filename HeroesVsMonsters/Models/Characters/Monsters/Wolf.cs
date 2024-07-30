using HeroesVsMonsters.Interfaces;

namespace HeroesVsMonsters.Models.Characters.Monsters;

public class Wolf : Monster, ILeather
{
    public int Leather { get; set; }

    public Wolf(string name) : base(name)
    {
        Leather = D4.Roll();
    }

}