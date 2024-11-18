public abstract class ItemDecorator : Item
{
    protected Item item;
    public ItemDecorator(Item item)
    {
        this.item = item;
    }

    public virtual void Use(Character character)
    {
         Console.WriteLine($"Menggunakan {item.Name}");
    }
}