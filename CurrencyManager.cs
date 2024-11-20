public class CurrencyManager
{
    public int TotalMoney { get; set; }

    public void AddMoney(int amount)
    {
        if (amount > 0)
        {
            TotalMoney += amount;
            Console.WriteLine($"Uang ditambahkan sebesar {amount}. Total uang: {TotalMoney}");
        }
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

    public void ShowBalance()
    {
        Console.WriteLine($"Saldo saat ini: {TotalMoney}");
    }
}
