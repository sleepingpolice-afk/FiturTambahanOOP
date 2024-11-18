public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    public abstract void TakeDamage(int damage);
}