public class EnemyFactory
{
    public static Enemy CreateEnemy(int level)
    {
        if (level == 1)
        {
            return new Tuyul();
        }
        else if (level == 2)
        {
            return new Pocong();
        }
        else if (level == 3)
        {
            return new Legendcoak(); // Level bos
        }
        else if (level == 4)
        {
            return new FireDragon();
        }
        else if (level == 5)
        {
            return new EternalKing();
        }
        else
        {
            return new Tuyul(); // Default to Legendcoak for higher levels
        }
    }
}
