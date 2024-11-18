public class HealthPotionDecorator : ItemDecorator
{
    public HealthPotionDecorator(Item item) : base(item) { }

    public override void Use(Character character)
    {
        base.Use(character);
        character.Health += 20;
        Console.WriteLine($"{character.Name} mendapat tambahan 20 HP!");
    }
}