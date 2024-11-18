public abstract class Enemy
{
    public string Name { get; set; } = "Unknown";
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Money { get; set; } //uang musuh

    public abstract void TakeDamage(float damage, Character character);
    public bool Alive()
    {
        return Health > 0;
    }
}