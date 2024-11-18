public class LevelUpSystem
{
    public void CheckLevelUp(Character character, int xp)
    {
        int xpNeeded = character.Level * 100;
        if (xp >= xpNeeded)
        {
            character.LevelUp();
            Console.WriteLine($"XP yang diperlukan untuk level berikutnya: {xpNeeded + 100}");
        }
        else
        {
            Console.WriteLine($"XP saat ini: {xp}/{xpNeeded}");
        }
    }
}