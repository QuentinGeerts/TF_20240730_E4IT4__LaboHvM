namespace HeroesVsMonsters.Interfaces;

public interface IHero
{
    void Loot(IEntity target);
    void Rest();
}