public class Manager
{
    private List<string> fingerprints;
    private static Manager instance;

    private Manager()
    {
        fingerprints = new List<string>();
    }

    public static Manager getInstance()
    {
        if(instance == null)
        {
            instance = new Manager();
        }
        return instance;
    }

    public void addFP(string fingerprint)
    {
        if (!checkFP(fingerprint))
        {
            fingerprints.Add(fingerprint);
        }
        else
        {
            throw new NotSupportedException("Fingerprint already exists");
        }
    }

    public void deleteFP(string fingerprint)
    {
        if (checkFP(fingerprint))
        {
            fingerprints.Remove(fingerprint);
        }
        else
        {
            throw new NotSupportedException("Fingerprint not found");
        }
    }

    public void modifyFP(string oldFingerprint, string newFingerprint)
    {
        var i = fingerprints.IndexOf(oldFingerprint);
        if (checkFP(oldFingerprint))
        {
            fingerprints.Insert(i, newFingerprint);
        }
        else
        {
            throw new NotSupportedException("Fingerprint not found");
        }
     
    }

    public bool checkFP(string fingerprint)
    {
       var i = fingerprints.IndexOf(fingerprint);
        if (i == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}

