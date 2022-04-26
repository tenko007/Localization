using System.Collections.Generic;
using Newtonsoft.Json;

public class JsonConverter : Singleton<JsonConverter>
{
    public string DictionaryToJson<T1,T2>(Dictionary<T1, T2> dict)
    {
        return JsonConvert.SerializeObject(dict, Formatting.Indented);
    }
    
    public Dictionary<T1,T2> JsonToDictionary<T1,T2>(string jsonText)
    {
        return JsonConvert.DeserializeObject<Dictionary<T1, T2>>(jsonText);
    }
}