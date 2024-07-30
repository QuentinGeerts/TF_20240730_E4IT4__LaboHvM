namespace HeroesVsMonsters.Interfaces;

public interface IEntity
{
    public string Name { get; }
    public int Hp { get; }
    public int HpMax { get; }

    public bool IsAlive { get; }

    public void Hit(IEntity target);
    public void ReceiveDamage(int amout);
}