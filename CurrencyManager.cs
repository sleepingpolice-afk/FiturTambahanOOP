public class CurrencyManager
{
    public int TotalMoney { get; private set; }

    public void AddMoney(int amount)
    {
        TotalMoney += amount;
        Console.WriteLine($"Uang ditambahkan sebesar {amount}. Total uang: {TotalMoney}");
    }

    public bool DeductMoney(int amount)
    {
        if (TotalMoney >= amount)
        {
            TotalMoney -= amount;
            Console.WriteLine($"Uang dikurangi sebesar {amount}. Sisa uang: {TotalMoney}");
            return true;
        }
        else
        {
            Console.WriteLine("Uang tidak cukup.");
            return false;
        }
    }
}