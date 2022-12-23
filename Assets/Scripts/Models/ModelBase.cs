using Newtonsoft.Json;
using UnityEngine;

public abstract class ModelBase<T> : MonoBehaviour
{
    protected string _key;
    protected T _data;

    public void SetKey(string key)
    {
        _key = key;
    }

    public T GetData()
    {
        var rawJson = PlayerPrefs.GetString(_key);
        if (string.IsNullOrEmpty(rawJson))
        {
            var result = CreateDefaultData();
            return result;
        }

        var data = JsonConvert.DeserializeObject<T>(rawJson);
        return data;
    }

    public void SaveData(T data)
    {
        var rawJson = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(_key, rawJson);
    }

    protected abstract T CreateDefaultData();
}
