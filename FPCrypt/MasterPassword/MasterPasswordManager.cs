public class MasterPasswordManager
{
    private string masterpassword { get; }

    public MasterPasswordManager(string password)
    {
        masterpassword = password;
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