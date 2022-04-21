public class MasterPasswordManager
{
    private string masterpassword;
    private static MasterPasswordManager instance;

    public MasterPasswordManager()
    {
    }

    public static MasterPasswordManager getInstance()
    {
        if (instance == null) {
            instance = new MasterPasswordManager();
            //TODO DESERIALIZE HERE
        }
        return instance;
    }

    public bool checkMasterpassword(string MP)
    {
        if (MP.Equals(masterpassword))
        {
            return true;
        }
        return false;
    }
}