[Serializable]
public class Fingerprint
{
    private string name;
    private string fingerprintValue;
    private DateTime dateTime;

    public Fingerprint(string name, string fingerprint)
    {
        this.name = name;
        this.fingerprintValue = fingerprint;
        dateTime = DateTime.Now;
    }

    public string getName()
    {
        return name;
    }

    public string getFingerprintValue()
    {
        return fingerprintValue;
    }

    public DateTime getDate()
    {
        return dateTime;
    }

}

