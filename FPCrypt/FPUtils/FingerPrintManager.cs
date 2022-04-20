public class FingerPrintManager
{
    private List<string> fingerprints;
    private static FingerPrintManager instance;

    private FingerPrintManager()
    {
        fingerprints = new List<string>();
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
    }

    public void deleteFP(string fingerprint)
    {
        if (!fingerprints.Remove(fingerprint))
        {
            throw new NotSupportedException("Fingerprint not found");
        }
    }

    public void modifyFP(string oldFingerprint, string newFingerprint)
    {
        if (!fingerprints.Contains(oldFingerprint)) {
            throw new NotSupportedException("Fingerprint not found");
        }
        var i = fingerprints.IndexOf(oldFingerprint);
        fingerprints.RemoveAt(i);
        fingerprints.Insert(i, newFingerprint);
    }

}
