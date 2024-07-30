using HeroesVsMonsters.enums;
using HeroesVsMonsters.Models.Characters.Heroes;
using HeroesVsMonsters.Models.Characters.Monsters;

namespace HeroesVsMonsters.Models;

public class Forest
{
    public string Name { get; set; }
    public Hero Hero { get; set; }
    public List<Monster> Monsters { get; set; }

    public Forest(string name)
    {
        Name = name;
        Monsters = new List<Monster>();
    }


    public void Play()
    {
        // 1. Création du héro
        CreateHero();
        
        // 2. Création des monstres
        CreateMonsters();
        
        // 3. Lancement des combats
        // 3.1 Victoire
        // 3.2 Game over

        Fight();

    }

    private void Fight()
    {
        foreach (Monster monster in Monsters.ToList())
        {
            bool isHeroTurn = true;
            while (Hero.IsAlive && monster.IsAlive)
            {
                if (isHeroTurn)
                {
                    Hero.Hit(monster);
                }
                else
                {
                    monster.Hit(Hero);
                }

                isHeroTurn = !isHeroTurn;
            }

            if (Hero.IsAlive)
            {
                Console.WriteLine($"{Hero.Name} a gagné contre {monster.Name}");
                Hero.Loot(monster);
                Hero.Rest();
                Monsters.Remove(monster);
            }
            else
            {
                break;
            }
        }

        if (Hero.IsAlive)
        {
            Console.WriteLine($"Féliciations {Hero.Name}, vous avez triomphé.");
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Console.WriteLine($"{Hero.Name} a perdu.");
    }

    private void CreateMonsters()
    {

        for (int i = 0; i < 10; i++)
        {
            int rndMonster = Random.Shared.Next(Enum.GetNames(typeof(MonsterType)).Length);
            switch (rndMonster)
            {
                case 0:
                    Monsters.Add(new Wolf("Wolfy"));
                    break;
                case 1:
                    Monsters.Add(new Orc("Thrann"));
                    break;
                case 2:
                    Monsters.Add(new Dragon("Smaug"));
                    break;
            }

            Console.WriteLine($"Monstre créé: {Monsters[i]}");
        }
    }

    private void CreateHero()
    {
        string choice = "";
        string pseudo = "";
        
        Console.WriteLine("Création du héro");
        Console.Write("1. Humain\n2. Nain\nChoix: ");
        choice = Console.ReadLine();

        while (choice != "1" && choice != "2")
        {
            Console.WriteLine("Choix: ");
            choice = Console.ReadLine();
        }

        Console.WriteLine("Entrez votre pseudo :");
        pseudo = Console.ReadLine();

        switch (choice)
        {
            case "1": 
                Hero = new Human(pseudo);
                break;
            default:
                Hero = new Dwarf(pseudo);
                break;
        }

        Console.WriteLine($"Héro créé: {Hero}");
    }
}