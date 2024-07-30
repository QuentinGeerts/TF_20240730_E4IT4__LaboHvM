namespace HeroesVsMonsters.Tools;

public class Dice(int maximum) // Constructeur primaire
{
    private int Maximum { get; init; } = maximum;
    private int Minimum { get; } = 1;

    public int Roll()
    {
        return Random.Shared.Next(Maximum) + Minimum;
    }
}