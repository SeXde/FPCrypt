public class Manager
{
    private List<string> fingerprints;
    private Manager instance;

    private Manager()
    {
        fingerprints = new List<string>();
    }

    public Manager()
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
        i = fingerprints.IndexOf(oldFingerprint);
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
        i = fingerprints.IndexOf(oldFingerprint);
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

