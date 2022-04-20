using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class FingerPrintManager
{
    private List<string> fingerprints;
    [NonSerialized]
    private static FingerPrintManager instance;
    [NonSerialized]
    private const string CLASS_FILE = "FingerPrintManager.class.bin";

    private FingerPrintManager()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        {
            if (stream.Length == 0)
            {
                fingerprints = new List<string>();
            }
            else
            {
                FingerPrintManager saved = formatter.Deserialize(stream) as FingerPrintManager;
                fingerprints = saved.getFingerprints();
            }
        }
        
    }

    public static FingerPrintManager getInstance()
    {
        if(instance == null)
        {
            instance = new FingerPrintManager();
        }
        return instance;
    }

    public void addFP(string fingerprint)
    {
        if (fingerprints.Contains(fingerprint))
        {
            throw new NotSupportedException("Fingerprint already exists");

        }
        fingerprints.Add(fingerprint);
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }

    public void deleteFP(string fingerprint)
    {
        if (!fingerprints.Remove(fingerprint))
        {
            throw new NotSupportedException("Fingerprint not found");
        }
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }

    public void modifyFP(string oldFingerprint, string newFingerprint)
    {
        if (!fingerprints.Contains(oldFingerprint)) {
            throw new NotSupportedException("Old fingerprint not found");
        }
        if (fingerprints.Contains(newFingerprint))
        {
            throw new NotSupportedException("New fingerprint already exists");
        }
        var i = fingerprints.IndexOf(oldFingerprint);
        fingerprints.RemoveAt(i);
        fingerprints.Insert(i, newFingerprint);
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }

    protected List<string> getFingerprints()
    {
        return fingerprints;
    }

}
