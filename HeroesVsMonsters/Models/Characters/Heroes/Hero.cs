using System.Text;
using HeroesVsMonsters.Interfaces;

namespace HeroesVsMonsters.Models.Characters.Heroes;

public abstract class Hero : Character, IHero, IGold, ILeather
{
    public int Gold { get; set; }
    public int Leather { get; set; }
    
    public Hero(string name) : base(name)
    {
    }

    public void Loot(IEntity target)
    {
        if (target is IGold)
        {
            Gold += ((IGold)target).Gold; // Cast explicite
        }

        if (target is ILeather targetLeather) // Pattern matching
        {
            Leather += targetLeather.Leather;
        }
    }

    public void Rest()
    {
        ResetHp();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Inventaire :");
        sb.AppendLine($" - Or: {Gold}");
        sb.AppendLine($" - Cuir: {Leather}");
        return base.ToString() + sb.ToString();
    }
}