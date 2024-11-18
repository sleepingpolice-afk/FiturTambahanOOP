public class LongRangeAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan jarak jauh!");
        enemy.TakeDamage(character.AttackPower + 5, character);
    }
}