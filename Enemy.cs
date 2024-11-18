public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Money { get; set; } //uang musuh

    public abstract void TakeDamage(int damage, Character character);
    public bool Alive()
    {
        return Health > 0;
    }
}