using System;

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

    public void TransferMoneyToItem(Item item, int amount)
    {
        if (DeductMoney(amount))
        {
            // Transfer uang ke item
            if (item is MoneyBag moneyBag)
            {
                moneyBag.Amount += amount;
                Console.WriteLine($"Uang ditransfer ke {moneyBag.Name}. Jumlah uang di dalam item: {moneyBag.Amount}");
            }
        }
    }
}
