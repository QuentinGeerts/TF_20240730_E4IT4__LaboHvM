using System.Text;
using HeroesVsMonsters.Interfaces;
using HeroesVsMonsters.Tools;

namespace HeroesVsMonsters.Models.Characters;

public abstract class Character : ICharacter
{
    
    // Properties
    public string Name { get; private set; }
    public virtual int Stamina { get; private set; }
    public virtual int Strength { get; private set; }
    public int Hp { get; private set; }
    public int HpMax { get; private set; }

    public bool IsAlive => Hp > 0;
    public Dice D4 { get; set; }
    public Dice D6 { get; set; }
    
    // Ctor
    protected Character(string name)
    {
        D4 = new Dice(4);
        D6 = new Dice(6);
        
        Name = name;
        Stamina = GenerateStat();
        Strength = GenerateStat();
        Hp = HpMax = Stamina + Modifier(Stamina);
    }

    private int Modifier(int stat)
    {
        if (stat < 5) return -1;
        else if (stat < 10) return 0;
        else if (stat < 15) return 1;
        else return 2;

        // return stat < 5 ? -1
        //     : stat < 10 ? 0
        //     : stat < 15 ? 1 
        //     : 2;
    }

    private int GenerateStat()
    {
        // Lancer les dés 4 fois
        // Prendre les 3 meilleurs
        // Somme des 3 meilleurs et la retournée

        int[] rolls = new int[4];

        for (int i = 0; i < 4; i++)
        {
            rolls[i] = D6.Roll();
        }

        // for (int i = 0; i < rolls.Length - 1; i++)
        // {
        //     for (int j = i + 1; j < rolls.Length; j++)
        //     {
        //         if (rolls[i] > rolls[j])
        //         {
        //             int temp = rolls[i];
        //             rolls[i] = rolls[j];
        //             rolls[j] = temp;
        //         }
        //     }
        // }
        //
        // return rolls[1] + rolls[2] + rolls[3];

        return rolls.OrderDescending().Take(3).Sum();
    }
    
    public void Hit(IEntity target)
    {
        int damage = D4.Roll() + Modifier(Strength);
        // target.Hp = target.Hp - damage;
        target.ReceiveDamage(damage);

        Console.WriteLine($"{Name} inflige {damage} points de dégâts à {target.Name}");
    }

    public void ReceiveDamage(int amout)
    {
        if (amout > 0) Hp -= amout;
    }

    protected void ResetHp()
    {
        Hp = HpMax;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Nom: {Name}");
        sb.AppendLine($"Endurance: {Stamina}");
        sb.AppendLine($"Force: {Strength}");
        sb.AppendLine($"PV: {Hp}");
        return sb.ToString();
    }
}