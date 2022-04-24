using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class FingerprintManager
{
    private IDictionary<string, Fingerprint> fingerprints;
    private HashSet<string> fingerprintNames;
    private int fingerprintCurrId;
    [NonSerialized]
    private static FingerprintManager instance;
    [NonSerialized]
    private const string CLASS_FILE = "FingerPrintManager.class.bin";

    private FingerprintManager()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        {
            if (stream.Length == 0)
            {
                fingerprints = new Dictionary<string, Fingerprint>();
                fingerprintCurrId = 1;
                fingerprintNames = new HashSet<string>();
            }
            else
            {
                FingerprintManager saved = formatter.Deserialize(stream) as FingerprintManager;
                fingerprints = saved.getMap();
                fingerprintCurrId = saved.getCurrentId();
                fingerprintNames = saved.getNames();

            }
        }
        
    }

    public static FingerprintManager getInstance()
    {
        if(instance == null)
        {
            instance = new FingerprintManager();
        }
        return instance;
    }

    public void addFP(Fingerprint fingerprint)
    {
        if (fingerprints.ContainsKey(fingerprint.getFingerprintValue()))
        {
            throw new NotSupportedException("Fingerprint already exists");

        }
        fingerprints.Add(fingerprint.getFingerprintValue(), fingerprint);
        fingerprintNames.Add(fingerprint.getName());
        fingerprintCurrId++;
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Truncate, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }

    public void deleteFP(Fingerprint fingerprint)
    {
        if (!fingerprints.Remove(fingerprint.getFingerprintValue()))
        {
            throw new NotSupportedException("Fingerprint not found");
        }
        fingerprintNames.Remove(fingerprint.getName());
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }

    public void modifyFP(Fingerprint oldFingerprint, Fingerprint newFingerprint)
    {
        if (!fingerprints.ContainsKey(oldFingerprint.getFingerprintValue())) {
            throw new NotSupportedException("Old fingerprint not found");
        }
        if (fingerprints.ContainsKey(newFingerprint.getFingerprintValue()))
        {
            throw new NotSupportedException("New fingerprint already exists");
        }
        fingerprints.Remove(oldFingerprint.getFingerprintValue());
        fingerprints.Add(newFingerprint.getFingerprintValue(), newFingerprint);
        fingerprintNames.Remove(oldFingerprint.getName());
        fingerprintNames.Add(newFingerprint.getName());
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, this);
        }
    }

    protected IDictionary<string, Fingerprint> getMap()
    {
        return fingerprints;
    }

    protected HashSet<string> getNames()
    {
        return fingerprintNames;
    }

    public int getCurrentId()
    {
        return fingerprintCurrId;
    }

    public Boolean isPresent(string fingerprintValue)
    {
        return fingerprints.ContainsKey(fingerprintValue);
    }

    public List<Fingerprint> getFingerprints()
    {
        return fingerprints.Values.ToList();
    }

    public Boolean isPickable(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("name");
        }
        return !fingerprintNames.Contains(name);
    }

}
