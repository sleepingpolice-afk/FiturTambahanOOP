<<<<<<< HEAD
 public interface IAttackStrategy
{
    void Attack(Character character, Enemy enemy);
}
=======
public class ShortAttack : IAttackStrategy
//Melakukan serangan jarak jauh dan dekat
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan jarak dekat!");
        enemy.TakeDamage(character.AttackPower, character);
    }
}

public class LongRangeAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan jarak jauh!");
        enemy.TakeDamage(character.AttackPower + 5, character);
    }
}
>>>>>>> 5ccf614e5e43041a081f848414811781b3297e60
