using System;
public class Character
{
    private static Character? instance;
    public string Name { get; set; }
    public float Health { get; set; }
    public int Level { get; set; }
    public float AttackPower { get; set; }
    public int Money { get; set; }
    public CurrencyManager CurrencyManager { get; set; } = new CurrencyManager();

    private Character()
    {
        Name = "Pemburu Harta Karun";
        Health = 100;
        Level = 1;
        AttackPower = 10;
        Money = 100;
    }

    public static Character Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Character();
            }
            return instance;
        }
    }

    public void LevelUp()
    {
        Level++;
        AttackPower += 5;
        Health += 20;
        Console.WriteLine($"{Name} naik level menjadi {Level}. HP: {Health}, Attack Power: {AttackPower}");
    }
    public void GainMoney(int amount)
    {
        Money += amount;
        Console.WriteLine($"{Name} mendapatkan {amount} uang. Total uang: {Money}");
    }

    public void SpendMoney(int amount)
    {
        CurrencyManager.DeductMoney(amount);
    }
}