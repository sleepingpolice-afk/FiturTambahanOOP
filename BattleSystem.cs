public class BattleSystem
{
    public void StartBattle(Character character, Enemy enemy, IAttackStrategy attackStrategy)
    {
        Console.WriteLine($"Pertarungan dimulai melawan {enemy.Name}!");
        attackStrategy.Attack(character, enemy);
    }
}
