public class NPCFactory
{
    public static NPC CreateNPC(string NPC)
    {
        switch(NPC)
        {
            case "Merchant":
                return new Merchant();
            default:
                return null;
        }
    }
}
