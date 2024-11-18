public class ShortAttack : IAttackStrategy
//Melakukan serangan jarak jauh dan dekat
{
    public void Attack(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} melakukan serangan jarak dekat!");
        enemy.TakeDamage(character.AttackPower, character);
    }
}