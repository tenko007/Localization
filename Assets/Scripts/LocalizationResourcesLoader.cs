using System.Collections.Generic;
using UnityEngine;

public class LocalizationResourcesLoader : ILocalizationLoader
{
    public void Save(string language, Dictionary<string, string> texts)
    {
        throw new System.NotImplementedException();
    }

    public Dictionary<string, string> Load(string language)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(Localization.Instance.CurrentLanguage.ToString());
        string textsString = textAsset.text;
        return JsonConverter.Instance.JsonToDictionary<string, string>(textsString);
    }
}