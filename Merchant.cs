using System.Threading;

class Merchant : NPC
{
    int choice;
    public Merchant()
    {
        name = "Merchant";
        minimumlevel = 1;
    }

    public override void Interaction(Character character)
    {
        if(character.Level < minimumlevel)
        {
            Console.WriteLine("Kamu melihat seorang pedagang keliling, namun dia berjalan terlalu cepat dan kamu kehilangan dia...");
            Thread.Sleep(1000);
            return;
        }

        Console.Clear();
        Thread.Sleep(1000);
        do{
            Console.Clear();
            Console.WriteLine("Kamu melihat seorang pedagang keliling. Dia berhenti di depanmu.");
            Console.WriteLine("Halo, selamat datang di toko saya!");
            Console.WriteLine("Apa yang ingin kamu lakukan?");
            Console.WriteLine("1. Beli Health Potion (-10 Gold)");
            Console.WriteLine("2. Jual Health Potion (+5 Gold)");
            Console.WriteLine("3. Keluar");
            choice = Convert.ToInt32(Console.ReadLine());
            if(choice == 1)
            {
                if(character.CurrencyManager.TotalMoney >= 10)
                {
                    character.CurrencyManager.TotalMoney -= 10;
                    Item.AddItem("Health Potion", 1);
                }
                else
                {
                    Console.WriteLine("Kamu sedang bokek.");
                }
                Thread.Sleep(1000);
            }
            else if (choice == 2)
            {
                if(Item.items["Health Potion"] > 0)
                {
                    character.CurrencyManager.TotalMoney += 5;
                    Item.AddItem("Health Potion", -1);
                }
                else
                {
                    Console.WriteLine("Dasar miskin.");
                }
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
                Thread.Sleep(1000);
            }
        } while(choice != 3);
    }
}