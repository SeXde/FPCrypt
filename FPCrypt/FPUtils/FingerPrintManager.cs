using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class FingerprintManager
{
    private IDictionary<string, Fingerprint> fingerprints;
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
            }
            else
            {
                FingerprintManager saved = formatter.Deserialize(stream) as FingerprintManager;
                fingerprints = saved.getMap();
                fingerprintCurrId = saved.getCurrentId();

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
        fingerprintCurrId++;
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(CLASS_FILE, FileMode.Create, FileAccess.Write, FileShare.None))
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

}
