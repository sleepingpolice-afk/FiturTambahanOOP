using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Character character = Character.Instance;
        int level = 1;

        Console.WriteLine($"Kau adalah {character.Name} (HP: {character.Health}, Attack Power: {character.AttackPower})");
        bool continuePlaying = true;

        while (continuePlaying == true)
        {
            Enemy enemy = EnemyFactory.CreateEnemy(level);

            Console.WriteLine($"\n== Level {level} : {GetLevelDescription(level)} ==");

            if (level == 1)
            {
                Console.WriteLine("Kau menunduk untuk melihat bocil botak balas menatapmu dengan matanya yang besar.");
                Console.WriteLine("Bocil itu mendadak menyeringai, memamerkan deretan gigi kecil runcing seperti Payara.");
                Console.WriteLine("Bocil itu terkikik. Suaranya melengkik nyaring, bergema di dok kecil itu.");
                Console.WriteLine("1. “Huh..?”");
                Console.WriteLine("2. “Anak hilang, mau permen?”");
                Console.WriteLine("3. *Bunuh*");

                string choice = Console.ReadLine();
                if (choice == "3")
                {
                    Console.WriteLine("> Kau memutuskan untuk melawan : Tuyul!");
                    ExecuteBattle(character, enemy);
                }
                else
                {
                    Console.WriteLine("Kau tidak menduga bocil itu menggigit tanganmu. Menolak melepaskan...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                    return;
                }
            }
            else if (level == 2)
            {
                Console.WriteLine("Kau mendengar suara di belakangmu. Suaranya seperti sesuatu yang berat dibanting ke lantai hutan.");
                Console.WriteLine("Kau terhenti. Berbalik.");
                Console.WriteLine("kau menyipitkan mata, pandanganmu menyapu sekitar. Tidak ada apa-apa. Kau menghela nafas. Kembali berbalik.");
                Console.WriteLine("Seseorang menantimu. Wajahnya yang membusuk hanya berjarak lima senti dari wajahmu. Wajah itu satu-satunya bagian darinya yang tidak ditutup buntalan putih yang ia sebut pakaian.");
                Console.WriteLine("Kau terlonjak. Secara insting melompat mundur.");
                Console.WriteLine("1. Kabur");
                Console.WriteLine("2. “Apa itu seharusnya membuatku takut?”");
                Console.WriteLine("3. Refleks nembak");

                string choice = Console.ReadLine();
                if (choice == "3")
                {
                    Console.WriteLine("> Kau memutuskan untuk melawan : Pocong!");
                    ExecuteBattle(character, enemy);
                }
                else
                {
                    Console.WriteLine("Pilihan yang tidak membuatmu berakhir dengan baik...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                    return;
                }
            }
            else if (level == 3)
            {
                Console.WriteLine("Kau melarikan diri ke dalam gua. Setelah beberapa saat, tak ada suara yang terdengar.");
                Console.WriteLine("1. Jelajahi gua");
                Console.WriteLine("2. Keluar");

                string choice = Console.ReadLine();
                if (choice == "2")
                {
                    Console.WriteLine("> Kau memutuskan untuk keluar.");
                    Console.WriteLine("Tak menyadari sosok di belakangmu tersenyum lebar…");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
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
                    Console.WriteLine("Kau yakin kau mencapai pusat gua. Kau mendengar gemerisik. Sesuatu sepertinya mengawasimu.");
                    Console.WriteLine("1. “Siapa itu?!”");
                    Console.WriteLine("2. *Diam supaya mereka tidak mendengarmu*");

                    string innerChoice = Console.ReadLine();

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
                    Console.WriteLine("Kau meneguk ludah.");
                    Console.WriteLine("1. Kabur");
                    Console.WriteLine("2. Tawarkan semua uangmu");
                    Console.WriteLine("3. “Fighting monsters? Huh. I got resume.”");
                    Console.WriteLine("4. Pura-pura mati");

                    string finalChoice = Console.ReadLine();
                    if (finalChoice == "3")
                    {
                        Console.WriteLine("> Kau memutuskan untuk melawan : Legendcoak!");
                        ExecuteBattle(character, enemy);
                    }
                    else
                    {
                        Console.WriteLine("Pilihan yang tidak membuatmu berakhir dengan baik...");
                        Console.Write("Game Over: ");
                        Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                        return;
                    }
                }
            }

            if (character.Health > 0 && !enemy.Alive())
            {
                Console.WriteLine($"\nSelamat! Kamu berhasil mengalahkan {enemy.Name}!");
                character.LevelUp();

                Console.WriteLine("Apakah Kamu mau melanjutkan perjalanan?");
                Console.WriteLine("1. HARTAKARUNHARTAKARUNHARTAKARUN");
                Console.WriteLine("2. ...Takut.");

                string continueChoice = Console.ReadLine();
                if (continueChoice == "1")
                {
                    level++;
                }
                else
                {
                    Console.WriteLine("Kau memutuskan untuk kembali ke dermaga dan belajar bahwa tidak ada uang di dunia ini yang patut ditukar dengan kebotakan");
                    continuePlaying = false;
                }
            }
            else
            {
                Console.WriteLine("\nThink before you act next time....");
                break;
            }
        }
    }

    static void ExecuteBattle(Character character, Enemy enemy)
    {
        BattleSystem battleSystem = new BattleSystem();
        battleSystem.ExecuteBattle(character, enemy);
    }

    static string GetLevelDescription(int level)
    {
        return level switch
        {
            1 => "The Island, The Dock, and The Curse",
            2 => "The Forest With Fog so Thick",
            3 => "The Ruin Where Your Sin Is Weighted Upon Your Soul",
            _ => "Unknown Level"
        };
    }
}