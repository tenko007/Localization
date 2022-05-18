using System;
using System.Collections.Generic;

public class Localization : Singleton<Localization>
{
    private ILocalizationLoader _localizationLoader = new LocalizationDirectoryLoader();

    private string _currentLanguage;// = "English";
    public string CurrentLanguage 
    {
        get
        {
            if (_currentLanguage == null)
                _currentLanguage = "English";
            return _currentLanguage;
        }
        set => SetLanguage(value);
    }

    public event Action OnLanguageChanged;  

    private Dictionary<string, string> _texts;

    public string GetText(string key)
    {
        if (_texts == null)
            SetLanguage(CurrentLanguage);
        
        if (_texts.TryGetValue(key, out string value))
            return value;
        return key;
    }

    public void SetLanguage(string language)
    {
        _currentLanguage = language;
        _texts = _localizationLoader.Load(language);
        OnLanguageChanged?.Invoke();
    }

    public void SaveLanguage(string language, Dictionary<string, string> texts)
    {
        _localizationLoader.Save(language, texts);
    }
}