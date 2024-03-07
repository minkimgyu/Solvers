using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonParser : MonoBehaviour
{
    public T ConvertJsonToData<T>(string data)
    {
        T value = JsonConvert.DeserializeObject<T>(data);
        return value;
    }
}
