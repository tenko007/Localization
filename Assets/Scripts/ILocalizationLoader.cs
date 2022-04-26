using System.Collections.Generic;

public interface ILocalizationLoader
{
    void Save(string language, Dictionary<string, string> texts);
    Dictionary<string, string> Load(string language);
}