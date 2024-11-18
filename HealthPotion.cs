public class HealthPotion : Item
{
    public int HealthRestore { get; set; }

    public HealthPotion()
    {
        Name = "Health Potion";
        HealthRestore = 20;
    }
}