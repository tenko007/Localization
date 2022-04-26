using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TestLocalization
{
    [Test]
    public void TestJsonConverter()
    {
        Dictionary<string, string> savedDictionary = new Dictionary<string, string>();
        Dictionary<string, string> loadedDictionary = new Dictionary<string, string>();
        savedDictionary.Add("1", "abc");
        savedDictionary.Add("2", "def");
        savedDictionary.Add("3", "ghi");
        string jsonText = JsonConverter.Instance.DictionaryToJson(savedDictionary);
        loadedDictionary = JsonConverter.Instance.JsonToDictionary<string, string>(jsonText);
        
        Assert.AreEqual(loadedDictionary.Count, savedDictionary.Count);
        
        foreach (var loadedField in loadedDictionary)
        {
            Assert.True(savedDictionary.TryGetValue(loadedField.Key, out string savedValue));
            Assert.AreEqual(savedValue, loadedField.Value);
        }
    }
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestLocalizationWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
