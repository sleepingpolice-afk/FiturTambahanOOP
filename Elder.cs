class Elder
{
    public string Name { get; set; }
    public string Role { get; set; }

    public Elder(string name, string role)
    {
        Name = name;
        Role = role;
    }

    public void Interact(int level, Character character)
    {
        Console.WriteLine($"\n{this.Name}: “{GetDialogue(level)}”");

        if (level == 1)
        {
            Console.WriteLine("1. Terima hadiah kesehatan (+20 HP)");
            Console.WriteLine("2. Abaikan dan lanjutkan perjalanan.");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                character.Health += 20;
                Console.WriteLine("> Elder Nara memberikan ramuan kesehatan. (+20 HP)");
            }
            else
            {
                Console.WriteLine("> Kau memutuskan untuk tidak menerima bantuannya.");
            }
        }
        else if (level == 3)
        {
            Console.WriteLine("1. Terima peta yang menunjukkan jalan aman.");
            Console.WriteLine("2. Tolak dan lanjutkan tanpa bantuan.");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("> Elder Nara memberikan peta yang menunjukkan rute terbaik di gua.");
            }
            else
            {
                Console.WriteLine("> Kau memilih untuk mencari jalan sendiri.");
            }
        }
        else
        {
            Console.WriteLine("> Elder Nara tersenyum dan menghilang ke dalam bayangan.");
        }
    }

    private string GetDialogue(int level)
    {
        return level switch
        {
            1 => "Aku adalah Elder Nara. Kesehatanmu tampak lemah. Mungkin ini bisa membantumu.",
            3 => "Kegelapan di depan akan menguji keberanianmu. Ambil peta ini, atau berjalan dengan kehendakmu sendiri.",
            5 => "Kuil ini penuh dengan bahaya. Kau akan membutuhkan semua keberanian yang kau miliki.",
            6 => "Hanya yang kuat yang pantas menghadapi Raja Keabadian. Pilih dengan bijak, petualang.",
            _ => "Perjalananmu panjang, tetaplah berhati-hati."
        };
    }
}
