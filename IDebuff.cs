public interface IDebuff
{
    void ApplyDebuff(Character character);
}

public class BurnDebuff : IDebuff
{
    public string name;
    public int damagePerTurn;
    public int turnsRemaining;

    public BurnDebuff(int damagePerTurn, int turnsRemaining)
    {
        name = "Burn Debuff";
        this.damagePerTurn = damagePerTurn;
        this.turnsRemaining = turnsRemaining;
    }

    public void ApplyDebuff(Character character)
    {
        Console.WriteLine($"{character.Name} terkena Burn Debuff! Mengurangi {damagePerTurn} HP per turn selama {turnsRemaining} turn.");
        Console.WriteLine("Sisa Turn: " + turnsRemaining);
        character.Health -= damagePerTurn;
        turnsRemaining--;

        if (turnsRemaining == 0)
        {
            Console.WriteLine("Burn Debuff telah hilang!");
            character.activeDebuff = new NoneDebuff();
        }
    }
}

public class NoneDebuff : IDebuff
{
    public string? name;

    public NoneDebuff()
    {
        name = "None";
    }
    public void ApplyDebuff(Character character)
    {
        character.hasDebuff = false;
    }
}