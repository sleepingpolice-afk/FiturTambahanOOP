using System;
using System.Threading;

public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Kau melarikan diri ke dalam gua. Setelah beberapa saat, tak ada suara yang terdengar.");
        Thread.Sleep(1000);
        Console.WriteLine("Kau mempertimbangkan apakah sebaiknya kau menjelajah gua ini lebih dalam atau kembali keluar.");
        Thread.Sleep(1000);
        Console.WriteLine("1. Jelajahi gua");
        Console.WriteLine("2. Keluar");

        string choice = Console.ReadLine();

        if (choice == "2")
        {
            Console.WriteLine("> Kau memutuskan untuk keluar.");
            Thread.Sleep(1000);
            Console.WriteLine("Melihat ke sekitar, hanya ada pepohonan hening.");
            Thread.Sleep(1000);
            Console.WriteLine("Kau menghembuskan nafas lega...");
            Thread.Sleep(3000);
            Console.WriteLine("Tak menyadari sosok di belakangmu tersenyum lebar…");
            Console.WriteLine("GAME OVER; nikmati potongan rambut barumu!");
            return;
        }
        else if (choice == "1")
        {
            Console.WriteLine("> Kau memutuskan untuk menjelajahi gua lebih jauh.");
            Thread.Sleep(1000);
            Console.WriteLine("Langit-langit gua itu tinggi, stalaktit menggantung seperti taring yang mengancam untuk menerkammu.");
            Thread.Sleep(1000);
            Console.WriteLine("Kau bergidik. Meneruskan perjalananmu...");
            Thread.Sleep(2000);

            Console.WriteLine("> Kau yakin kau mencapai pusat gua. Tempat itu lebar. Kau mendengar gemerisik. Sesuatu sepertinya mengawasimu.");
            Thread.Sleep(1000);
            Console.WriteLine("1. “Siapa itu?!”");
            Console.WriteLine("2. *Diam supaya mereka tidak mendengarmu*");

            string innerChoice = Console.ReadLine();
            Thread.Sleep(2000);

            Console.WriteLine("> Suara gemerisik terdengar lagi.");
            Thread.Sleep(1000);
            Console.WriteLine("Kau mencium bau yang familiar. Terlalu familiar. Basemu memiliki bau yang sama...");
            Thread.Sleep(1000);
            Console.WriteLine("Sesuatu yang halus dan panjang mengelus tenguk mu. Seperti sehelai rambut...");
            Thread.Sleep(1000);
            Console.WriteLine("Kau berbalik.");
            Thread.Sleep(2000);
            Console.WriteLine("Sepasang mata balas menatap ke arahmu. Mata itu tak menunjukkan emosi. Kau bisa melihat dirimu dipantukan oleh manik hitam legam seperti malam.");
            Thread.Sleep(1000);
            Console.WriteLine("Yang menyentuh tengukmu adalah antena. Sepasang antena melengkung mengancam.");
            Thread.Sleep(1000);
            Console.WriteLine("Panjang antena itu dua kali kamu.");
            Thread.Sleep(1000);
            Console.WriteLine("Makhluk itu merangkak perlahan. Tiga pasang kaki bergerak dengan bulu-bulu halus di masing-masing kakinya...");
            Thread.Sleep(3000);
            Console.WriteLine("Ia menggeram rendah. Seperti peringatan.");

            Console.WriteLine("> Kau meneguk ludah.");
            Console.WriteLine("1. Kabur");
            Console.WriteLine("2. Tawarkan semua uangmu");
            Console.WriteLine("3. “Fighting monsters? Huh. I got records.”");
            Console.WriteLine("4. Pura-pura mati");

            string finalChoice = Console.ReadLine();
            if (finalChoice == "3")
            {
                Console.WriteLine("> Kau memutuskan untuk melawan : Legendcoak!");
                Thread.Sleep(1000);

                Character character = Character.Instance;

                Enemy enemy = new Legendcoak();

                BattleSystem battleSystem = new BattleSystem();
                battleSystem.ExecuteBattle(character, enemy);

                if (character.Health > 0 && !enemy.Alive())
                {
                    Console.WriteLine("\nSelamat! Kamu berhasil mengalahkan Kecoak Legendaris!");
                }
                else
                {
                    Console.WriteLine("\nKamu kalah dalam pertarungan melawan Kecoak Legendaris.");
                }
            }
            else
            {
                Console.WriteLine("> Pilihan yang tidak membuatmu berakhir dengan baik...");
                Console.WriteLine("GAME OVER; sosok itu menatapmu dengan puas.");
            }
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid. Permainan berakhir.");
        }
    }
}
