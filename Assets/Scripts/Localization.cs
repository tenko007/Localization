using System.Collections.Generic;
using UnityEditor;

public class Localization : Singleton<Localization>
{
    private ILocalizationLoader _localizationLoader = new LocalizationLoader();
    
    private string _currentLanguage;
    public string CurrentLanguage => _currentLanguage;

    private Dictionary<string, string> _texts;

    public string GetText(string key)
    {
        if (_texts.TryGetValue(key, out string value))
            return value;
        return key;
    }

    public void SetLanguage(string language)
    {
        _currentLanguage = language;
        _texts = _localizationLoader.Load(language);
    }

    public void SaveLaguage(string language, Dictionary<string, string> texts)
    {
        _localizationLoader.Save(language, texts);
    }
}