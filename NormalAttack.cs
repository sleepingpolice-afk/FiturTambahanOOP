public class NormalAttack : IAttackStrategy
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan normal!");
        enemy.TakeDamage(character.AttackPower);
    }
}