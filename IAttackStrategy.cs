// Strategy Pattern untuk variasi serangan.
public interface IAttackStrategy
{
    void Attack(Character character, Enemy enemy);
}

public class NormalAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan normal!");
        enemy.TakeDamage(character.AttackPower);
    }
}

public class StrongAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
        int strongDamage = character.AttackPower * 2;
        Console.WriteLine($"{character.Name} melakukan serangan kuat!");
        enemy.TakeDamage(strongDamage);
    }
}
