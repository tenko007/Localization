using System.Collections.Generic;
using System.IO;

public class LocalizationLoader : ILocalizationLoader
{
    //private string DirectoryPath = System.AppContext.BaseDirectory + "/Directory";
    public const string LocalizationDirectory = "Localization";
    public void Save(string language, Dictionary<string, string> texts)
    {
        var jsonText = JsonConverter.Instance.DictionaryToJson(texts);
        File.WriteAllText(GetFilePath(language), jsonText);
    }

    public Dictionary<string, string> Load(string language)
    {
        return ReadDataFromFile(language);
    }

    private Dictionary<string,string> ReadDataFromFile(string language)
    {
        string jsonText = File.ReadAllText(GetFilePath(language));
        return JsonConverter.Instance.JsonToDictionary<string, string>(jsonText);
    }

    public string GetFilePath(string language)
    {
        if (!Directory.Exists(LocalizationDirectory))
            Directory.CreateDirectory(LocalizationDirectory);
        
        return $"{LocalizationDirectory}/{language}.txt";
    }
}