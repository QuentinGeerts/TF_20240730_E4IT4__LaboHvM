using System.Text;
using HeroesVsMonsters.Interfaces;

namespace HeroesVsMonsters.Models.Characters.Monsters;

public abstract class Monster : Character, IMonster
{
    protected Monster(string name) : base(name)
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Inventaire :");
        if (this is IGold monsterGold) sb.AppendLine($" - Or: {monsterGold.Gold}");
        if (this is ILeather monsterLeather) sb.AppendLine($" - Cuir: {monsterLeather.Leather}");
            
        return base.ToString() + sb.ToString();
    }
}