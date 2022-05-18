using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TestSaveAndLoadLocalization
{
    [Test]
    public void SaveLocalization()
    {
        string language = "TestLanguage";
        
        Dictionary<string, string> languageTexts = new Dictionary<string, string>();
        
        languageTexts.Add("FIRST_GREETINGS", "Hello, World!");
        languageTexts.Add("NEW_QUEST", "You've got a new quest!");
        languageTexts.Add("NEW_ITEM", "There is a new item in your inventory!");
        
        Localization.Instance.SaveLanguage(language, languageTexts);
        Localization.Instance.SetLanguage(language);

        Assert.AreEqual(Localization.Instance.GetText("FIRST_GREETINGS"), "Hello, World!");
        Assert.AreEqual(Localization.Instance.GetText("NEW_QUEST"), "You've got a new quest!");
        Assert.AreEqual(Localization.Instance.GetText("NEW_ITEM"), "There is a new item in your inventory!");
    }
}