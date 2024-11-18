public class StrongAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
         int strongDamage = character.AttackPower * 2;
        Console.WriteLine($"{character.Name} melakukan serangan kuat!");
        enemy.TakeDamage(strongDamage);
    }
}