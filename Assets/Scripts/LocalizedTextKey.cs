[System.Serializable]
public class LocalizedTextKey
{
    public string key;

    public LocalizedTextKey(string key) => this.key = key;
    public string value => Localization.Instance.GetText(key);
    public static implicit operator LocalizedTextKey(string key) =>
        new LocalizedTextKey(key);
}