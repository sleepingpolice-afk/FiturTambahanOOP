public abstract class Enemy
{
    public string Name { get; set; } = "Unknown";
    public float Health { get; set; }
    public float AttackPower { get; set; }
    public int Money { get; set; }

    public abstract void TakeDamage(float damage, Character character);

    public bool Alive()
    {
        return Health > 0;
    }
}
