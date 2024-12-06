using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Character character = Character.Instance;
        Item inventory = new Item();
        GameOverMessage ending = new GameOverMessage();
        int level = 1;
        character.CurrencyManager.AddMoney(100);
        Console.WriteLine(character.CurrencyManager.TotalMoney);

        Console.WriteLine($"Kau adalah {character.Name} (HP: {character.Health}, Attack Power: {character.AttackPower})");

        Item.AddItem(new HealthPotion().Name, 8);
        // Item.AddItem
        bool continuePlaying = true;

        while (continuePlaying == true)
        {
            Enemy enemy = EnemyFactory.CreateEnemy(level);

            Console.WriteLine($"\n== Level {level} : {GetLevelDescription(level)} ==");

            if (level == 1)
            {
                elder elderNara = new elder("Elder Nara", "Helper");
                elderNara.Interact(level, character);
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
                    ExecuteBattle(character, enemy, inventory);
                }
                else
                {
                    Console.WriteLine("Kau tidak menduga bocil itu menggigit tanganmu. Menolak melepaskan...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                    character.Health = -1;
                    continuePlaying = false;
                    //return;
                }

                Random random1 = new Random();
                if(random1.Next(1, 80) < 100 && continuePlaying == true) //80 persen chance encounter Merchant
                {
                    NPCFactory.CreateNPC("Merchant").Interaction(character);
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
                    ExecuteBattle(character, enemy, inventory);
                }
                else
                {
                    Console.WriteLine("Pilihan yang tidak membuatmu berakhir dengan baik...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                    character.Health = -1; //instant death
                    continuePlaying = false;
                }
            }
            else if (level == 3)
            {
                elder elderNara = new elder("Elder Nara", "Helper");
                elderNara.Interact(level, character);
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
                    character.Health = -1;
                    continuePlaying = false;
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
                        ExecuteBattle(character, enemy, inventory);
                    }
                    else
                    {
                        Console.WriteLine("Pilihan yang tidak membuatmu berakhir dengan baik...");
                        Console.Write("Game Over: ");
                        Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                        GameOver(character, ending);
                        //return;
                    }
                }
            }

            else if (level == 4)
            {
                // =========================== Story Level 4 ===========================
                Console.WriteLine("Kau keluar dari gua dan menemukan dirimu di padang gurun yang luas. Angin panas menerpa wajahmu.");
                Console.WriteLine("Di kejauhan, kau melihat sesuatu bergerak. Bayangan hitam besar...");
                Console.WriteLine("Saat kau mendekat, kau menyadari itu adalah seekor naga yang bersinar di bawah matahari.");
                Console.WriteLine("Naga itu membuka matanya yang besar dan menyala-nyala, menatapmu dengan penuh perhitungan.");
                Console.WriteLine("1. Berlutut dan memberikan penghormatan");
                Console.WriteLine("2. Melarikan diri");
                Console.WriteLine("3. Mengangkat senjata dan bersiap melawan");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("> Naga itu tampak terkejut, tetapi ia tersenyum kecil. Ia memberikanmu sebuah kunci emas dan berkata:");
                    Console.WriteLine("\"Kunci ini akan membawamu ke tempat yang lebih gelap, tetapi hadiah menantimu di sana.\"");
                    Console.WriteLine("Kau mendapatkan Kunci Emas!");
                    Item.AddItem("Golden Key", 1);
                    level++;
                }
                else if (choice == "2")
                {
                    Console.WriteLine("> Kau mencoba melarikan diri, tetapi naga itu mengejarmu dengan kecepatan luar biasa.");
                    Console.WriteLine("Dalam sekejap, ia mendarat di hadapanmu dan mengaum dengan keras.");
                    Console.WriteLine("Kau terjatuh, dan naga itu mengakhiri hidupmu...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                    character.Health = -1;
                    continuePlaying = false;
                }
                else if (choice == "3")
                {
                    Console.WriteLine("> Kau mengangkat senjata dan memutuskan untuk melawan : Naga Api!");
                    ExecuteBattle(character, enemy, inventory);

                    if (enemy.Alive())
                    {
                        Console.WriteLine("Naga itu terlalu kuat. Kau kalah dalam pertempuran...");
                        Console.Write("Game Over: ");
                        Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                        character.Health = -1;
                        continuePlaying = false;
                    }
                }
                else
                {
                    Console.WriteLine("Pilihan tidak jelas, naga itu bingung tapi tetap memakanmu.");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Wrong Choice"));
                    character.Health = -1;
                    continuePlaying = false;
                }
            }

            else if (level == 5)
            {
                elder elderNara = new elder("Elder Nara", "Helper");
                elderNara.Interact(level, character);
                Console.WriteLine("Kau memasuki sebuah kuil kuno yang tertutup bayangan gelap.");
                Console.WriteLine("Relief dinding di kuil itu seperti mengawasi setiap langkahmu.");
                Console.WriteLine("1. Periksa relief itu lebih dekat.");
                Console.WriteLine("2. Abaikan dan terus maju.");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("> Relief itu bergerak! Sebuah lengan batu mencoba menangkapmu!");
                    Console.WriteLine("1. Kabur");
                    Console.WriteLine("2. Serang relief itu dengan senjatamu.");

                    string innerChoice = Console.ReadLine();
                    if (innerChoice == "2")
                    {
                        Console.WriteLine("> Kau berhasil menghancurkan lengan batu itu, dan melanjutkan perjalanan.");
                    }
                    else
                    {
                        Console.WriteLine("Relief itu menangkapmu dan menyeretmu ke kegelapan...");
                        Console.Write("Game Over: ");
                        Console.WriteLine(GameOverMessage.GetMessage("Trapped in the Shadows"));
                        GameOver(character, ending);
                        continuePlaying = false;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Kau terus maju, tapi sesuatu terasa tidak beres...");
                }

                Console.WriteLine("Saat kau mencapai tengah kuil, seekor naga bayangan muncul, matanya memancarkan kilatan merah.");
                Console.WriteLine("1. Bernegosiasi");
                Console.WriteLine("2. Serang langsung");

                string finalChoice = Console.ReadLine();
                if (finalChoice == "2")
                {
                    Console.WriteLine("> Kau memutuskan untuk melawan : Shadow Dragon!");
                    ExecuteBattle(character, enemy, inventory);
                }
                else
                {
                    Console.WriteLine("Naga itu mengabaikan usahamu untuk bernegosiasi dan melahapmu hidup-hidup...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Eaten by the Dragon"));
                    GameOver(character, ending);
                    continuePlaying = false;
                    return;
                }
            }

            else if (level == 6)
            {
                Console.WriteLine("Kau mencapai puncak perjalananmu, di depanmu adalah singgasana bercahaya.");
                Console.WriteLine("Di atas singgasana itu duduk seorang raja berjubah emas, memegang tongkat yang memancarkan aura keabadian.");
                Console.WriteLine("1. Tantang raja itu");
                Console.WriteLine("2. Bersujud dan meminta ampun");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("> Kau memutuskan untuk melawan : Eternal King!");
                    ExecuteBattle(character, enemy, inventory);

                    if (character.Health > 0 && !enemy.Alive())
                    {
                        Console.WriteLine("Selamat! Kau telah mengalahkan Eternal King!");
                        Console.WriteLine("Raja itu memberikan tongkatnya sebagai simbol kemenanganmu.");
                        Console.WriteLine("Dunia kini berada dalam kedamaian berkat keberanianmu...");
                        Console.WriteLine("Ending: The Hero's Triumph");
                    }
                    else
                    {
                        Console.WriteLine("Raja itu terlalu kuat. Kau kalah...");
                        Console.Write("Game Over: ");
                        Console.WriteLine(GameOverMessage.GetMessage("Defeated by the Eternal King"));
                        GameOver(character, ending);
                        continuePlaying = false;
                    }
                }
                else
                {
                    Console.WriteLine("Raja itu memandangmu dengan jijik. 'Pengecut tidak layak hidup,' katanya.");
                    Console.WriteLine("Kau dihabisi oleh pasukan raja...");
                    Console.Write("Game Over: ");
                    Console.WriteLine(GameOverMessage.GetMessage("Fell to Cowardice"));
                    GameOver(character, ending);
                    continuePlaying = false;
                }

                continuePlaying = false; // Ending definitif
                Console.WriteLine("Terima kasih telah bermain! Sampai jumpa di petualangan selanjutnya.");
            }
            // === Level 6 Code End ===

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
                    character.Health = -1;
                    continuePlaying = GameOver(character, ending);
                    if(continuePlaying == false)
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nThink before you act next time....");
                level = 1;
                continuePlaying = GameOver(character, ending);
                if (continuePlaying == false)
                {
                    break;
                }
            }
        }
    }

    static bool GameOver(Character character, GameOverMessage ending)
    {
        bool continuePlaying;
        Console.WriteLine("Masukkan nama ke Leaderboard: ");
        ending.AddToLeaderboard(Console.ReadLine(), character.CurrencyManager.TotalMoney);
        ending.ShowLeaderboard();
        Console.WriteLine("Apakah kamu ingin bermain lagi? Press 1 to Continue....");
        string? continuechoice = Console.ReadLine();

        if (continuechoice == "1")
        {
            continuePlaying = true;
            Console.WriteLine("Waktu berputar kembali ke awal...");
            Thread.Sleep(2000);
            character.Health = 100;
            character.AttackPower = 10;
            character.Level = 1;
            character.CurrencyManager.TotalMoney = 300;
            //Item.AddItem(new HealthPotion().Name, 8);
        }
        else
        {
            continuePlaying = false;
            Console.WriteLine("Terima kasih telah bermain!");
        }

        return continuePlaying;
    }

    static void ExecuteBattle(Character character, Enemy enemy, Item inventory)
    {
        BattleSystem battleSystem = new BattleSystem();
        battleSystem.ExecuteBattle(character, enemy, inventory);
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