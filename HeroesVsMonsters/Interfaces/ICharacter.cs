namespace HeroesVsMonsters.Interfaces;

public interface ICharacter : IEntity
{
    public int Stamina { get; }
    public int Strength { get; }
}