using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class MasterPasswordManager
{
    private string masterpassword;
    [NonSerialized]
    private const string CLASS_FILE = "MasterPasswordManager.class.bin";
    [NonSerialized]
    private static MasterPasswordManager instance;

    private MasterPasswordManager()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        {
            if (stream.Length == 0)
            {
                masterpassword = null;
            }
            else
            {
                MasterPasswordManager saved = formatter.Deserialize(stream) as MasterPasswordManager;
                masterpassword = saved.getPassword();
            }
        }
    }

    protected string getPassword()
    {
        return masterpassword;
    }

    public static MasterPasswordManager getInstance()
    {
        if (instance == null) {
            instance = new MasterPasswordManager();
        }
        return instance;
    }

    public bool isFirstTime()
    {
        return masterpassword == null;
    }

    public bool checkMasterpassword(string MP)
    {
        if (isFirstTime())
        {
            throw new InvalidOperationException("Master password is not set");
        }
        if (masterpassword.Equals(MP))
        {
            return true;
        }
        return false;
    }

    public void setPassword(string password)
    {
        if (password == null)
        {
            throw new ArgumentNullException("password");
        }
        masterpassword = password;
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }
}
